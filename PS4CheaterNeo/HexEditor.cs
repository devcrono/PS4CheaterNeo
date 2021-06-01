﻿using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static PS4CheaterNeo.SectionTool;

namespace PS4CheaterNeo
{
    public partial class HexEditor : Form
    {
        readonly Main mainForm;
        readonly Section section;
        List<long> changedPosList;
        int Page;
        int PageCount;
        long Line;
        int Column;
        const int PageSize = 8 * 1024 * 1024;

        public HexEditor(Main mainForm, Section section, int baseAddr)
        {
            InitializeComponent();

            changedPosList = new List<long>();
            this.mainForm = mainForm;
            this.section = section;
            Page = baseAddr / PageSize;
            Line = (baseAddr - Page * PageSize) / HexView.BytesPerLine;
            Column = (baseAddr - Page * PageSize) % HexView.BytesPerLine;

            PageCount = DivUP(section.Length, PageSize);

            for (int i = 0; i < PageCount; ++i)
            {
                ulong start = section.Start + (ulong)i * PageSize;
                ulong end = section.Start + (ulong)(i + 1) * PageSize;
                PageBox.Items.Add((i + 1).ToString("00") + String.Format(" {0:X8}-{1:X8}", start, end));
            }
        }

        #region Event
        private void HexEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DynamicByteProvider dynaBP = HexView.ByteProvider as DynamicByteProvider;

            if (dynaBP.HasChanges() && MessageBox.Show("Byte data has changes, Do you want to close HexEditor?", "HexEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) e.Cancel = true;


        }
        private void HexView_SelectionStartChanged(object sender, EventArgs e)
        {
            if (HexView.SelectionStart <= 0) return;
            if (HexView.SelectionStart >= HexView.ByteProvider.Length) return;

            DynamicByteProvider dynaBP = HexView.ByteProvider as DynamicByteProvider;

            List<byte> tmpBList = new List<byte>();
            int info1 = 0, info2 = 0;
            uint info4 = 0;
            ulong info8 = 0;
            float infoF = 0;
            double infoD = 0;

            for (int idx = 0; idx <= 8; ++idx)
            {
                switch (idx)
                {
                    case 1:
                        info1 = Convert.ToUInt16(tmpBList[0]);
                        break;
                    case 2:
                        info2 = BitConverter.ToUInt16(tmpBList.ToArray(), 0);
                        break;
                    case 4:
                        info4 = BitConverter.ToUInt32(tmpBList.ToArray(), 0);
                        infoF = BitConverter.ToSingle(tmpBList.ToArray(), 0);
                        break;
                    case 8:
                        info8 = BitConverter.ToUInt64(tmpBList.ToArray(), 0);
                        infoD = BitConverter.ToDouble(tmpBList.ToArray(), 0);
                        break;
                }
                if (HexView.SelectionStart + idx < dynaBP.Length) tmpBList.Add(dynaBP.ReadByte(HexView.SelectionStart + idx));
                else tmpBList.Add(0);
            }
            InfoBox.Text = string.Format(@"{0:X}（{1:X}+{2:X}）

1: {3:X8}={3}
2: {4:X8}={4}
4: {5:X8}={5}
8: {6:X8}={6}
F: {7}
D: {8}", HexView.SelectionStart + HexView.LineInfoOffset, HexView.SelectionStart + HexView.LineInfoOffset - (long)section.Start, section.Start, info1, info2, info4, info8, infoF, infoD);
            
        }

        private void HexEditor_Load(object sender, EventArgs e)
        {
            PageBox.SelectedIndex = Page;
        }

        private void PageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page = PageBox.SelectedIndex;

            UpdateUi(Page, Line);
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            if (Page <= 0) return;

            Page--;
            Line = 0;
            Column = 0;
            PageBox.SelectedIndex = Page;
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (Page + 1 >= PageCount) return;

            Page++;
            Line = 0;
            Column = 0;
            PageBox.SelectedIndex = Page;
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            PageBox.SelectedIndex = Page;
            Line = HexView.CurrentLine - 1;
            Column = 0;
            UpdateUi(Page, Line);
        }

        private void CommitBtn_Click(object sender, EventArgs e)
        {
            DynamicByteProvider dynaBP = HexView.ByteProvider as DynamicByteProvider;
            if (!dynaBP.HasChanges()) return;

            byte[] buffer = dynaBP.Bytes.ToArray();

            for (int i = 0; i < changedPosList.Count; ++i)
            {
                byte[] b = { buffer[changedPosList[i]] };
                PS4Tool.WriteMemory(section.PID, (ulong)(changedPosList[i] + HexView.LineInfoOffset), b);
            }
            changedPosList.Clear();
        }

        private void AddToCheatGridBtn_Click(object sender, EventArgs e)
        {
            if (HexView.SelectionStart <= 0) return;

            DynamicByteProvider dynaBP = HexView.ByteProvider as DynamicByteProvider;
            ulong address = (ulong)(HexView.SelectionStart + HexView.LineInfoOffset);

            byte[] value;
            ScanType scanType;

            List<byte> tmpBList = new List<byte>();
            for (int idx = 0; idx <= 8; ++idx) tmpBList.Add(dynaBP.ReadByte(HexView.SelectionStart + idx));
            switch (HexView.SelectionLength)
            {
                case 1:
                    value = tmpBList.GetRange(0, 1).ToArray();
                    scanType = ScanType.Byte_;
                    break;
                case 2:
                    value = tmpBList.GetRange(0, 2).ToArray();
                    scanType = ScanType.Bytes_2;
                    break;
                case 4:
                    value = tmpBList.GetRange(0, 4).ToArray();
                    scanType = ScanType.Bytes_4;
                    break;
                case 8:
                    value = tmpBList.GetRange(0, 8).ToArray();
                    scanType = ScanType.Bytes_8;
                    break;
                default:
                    value = tmpBList.GetRange(0, 4).ToArray();
                    scanType = ScanType.Bytes_4;
                    break;
            }
            NewAddress newAddress = new NewAddress(mainForm, section, address, scanType, ScanTool.BytesToULong(scanType, ref value), false, "", false);
            if (newAddress.ShowDialog() != DialogResult.OK)
                return;
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FindOptions findOptions = new FindOptions();
                findOptions.Type = FindType.Hex;

                if (HexBox.Checked) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Hex, InputBox.Text);
                else if (Regex.IsMatch(InputBox.Text, @"\d+\.\d+"))
                {
                    if (float.TryParse(InputBox.Text, out float resultF)) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Float_, InputBox.Text);
                    else if (double.TryParse(InputBox.Text, out double resultD)) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Double_, InputBox.Text);
                }
                else if (UInt64.TryParse(InputBox.Text, out ulong result))
                {
                    if (result <= 0xFF) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Byte_, InputBox.Text); //255
                    else if (result <= 0xFFFF) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Bytes_2, InputBox.Text); //65535
                    else if (result <= 0xFFFFFF) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Bytes_4, InputBox.Text); //16777215
                    else if (result <= 0xFFFFFFFF) findOptions.Hex = ScanTool.ValueStringToByte(ScanType.Bytes_8, InputBox.Text); //4294967295
                }
                
                HexView.Find(findOptions);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        #endregion

        private int DivUP(int sum, int div)
        {
            return sum / div + ((sum % div != 0) ? 1 : 0);
        }

        private void UpdateUi(int page, long line)
        {
            HexView.LineInfoOffset = (long)section.Start + (long)(PageSize * page);

            int memSize = PageSize;

            if (section.Length - PageSize * page < memSize)
            {
                memSize = section.Length - PageSize * page;
            }

            byte[] dst = PS4Tool.ReadMemory(section.PID, section.Start + (ulong)page * PageSize, (int)memSize);
            HexView.ByteProvider = new DynamicByteProvider(dst);
            HexView.ByteProvider.Changed += ByteProvider_Changed;
            if (line != 0)
            {
                HexView.SelectionStart = line * HexView.BytesPerLine + Column;
                HexView.SelectionLength = 4;
                if (HexView.ColumnInfoVisible) line -= 2;

                HexView.ScrollByteIntoView((line + HexView.Height / (int)HexView.CharSize.Height - 1) * HexView.BytesPerLine + Column);
            }
        }
        private void ByteProvider_Changed(object sender, EventArgs e)
        {
            if (HexView.SelectionStart < 0) return;

            changedPosList.Add(HexView.SelectionStart);
        }
    }
}
