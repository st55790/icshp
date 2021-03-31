using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string file = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Vyber soubor";
            openDialog.Filter = "PCX soubor (*.pcx)|*.pcx;";
            openDialog.CheckFileExists = true;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                file = openDialog.FileName;
            }
            if (file != "")
            {
                Bitmap bitmap = LoadPCX(file);
                pictureBox.Image = bitmap;
            }
            else
            {
                MessageBox.Show("Soubor se nepodařilo správně načíst nebo nebyl vybrán");
            }
        }

        Bitmap LoadPCX(string filename)
        {
            Bitmap bitMap = null;
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            byte tmpByte = (byte)fileStream.ReadByte();
            if (tmpByte != 10)
            {
                MessageBox.Show("Tento soubor není PCX");
            }
            tmpByte = (byte)fileStream.ReadByte();
            if (tmpByte < 3 || tmpByte > 5)
            {
                MessageBox.Show("Pouze verze 3, 4 a 5 PCX jsou podporovány");
            }
            tmpByte = (byte)fileStream.ReadByte();
            if (tmpByte != 1)
            {
                MessageBox.Show("Špatný typ komprese");
            }

            int imgBpp = fileStream.ReadByte();
            if (imgBpp != 8 && imgBpp != 4 && imgBpp != 2 && imgBpp != 1)
            {
                MessageBox.Show("Pouze 8,4,2,1 a 1-bit PCX jsou podporovány");
            }

            short xmin = binaryReader.ReadInt16();
            short ymin = binaryReader.ReadInt16();
            short xmax = binaryReader.ReadInt16();
            short ymax = binaryReader.ReadInt16();

            int imgW = xmax - xmin + 1;
            int imgH = ymax - ymin + 1;

            this.Width = pictureBox.Width = imgW;
            this.Height = pictureBox.Height = imgH;

            short hdpi = binaryReader.ReadInt16();
            short vdpi = binaryReader.ReadInt16();

            byte[] colorPalette = new byte[48];
            fileStream.Read(colorPalette, 0, 48);
            fileStream.ReadByte();

            int numPlanes = fileStream.ReadByte();
            int bytesPerLine = binaryReader.ReadInt16();
            if (bytesPerLine == 0)
            {
                bytesPerLine = xmax - xmin + 1;
            }

            bool bitPlanesLiteral = false;

            binaryReader.ReadInt16();

            if (imgBpp == 8 && numPlanes == 1)
            {
                colorPalette = new byte[768];
                fileStream.Seek(-768, SeekOrigin.End);
                fileStream.Read(colorPalette, 0, 768);
            }

            if (imgBpp == 1)
            {
                if ((colorPalette[0] == colorPalette[3]) &&
                    (colorPalette[1] == colorPalette[4]) &&
                    (colorPalette[2] == colorPalette[5]))
                {
                    colorPalette[0] = colorPalette[1] = colorPalette[2] = 0;
                    colorPalette[3] = colorPalette[4] = colorPalette[5] = 0xFF;
                }
            }

            byte[] bmpData = new byte[(imgW + 1) * 4 * imgH];
            fileStream.Seek(128, SeekOrigin.Begin);

            int x = 0;
            int y = 0;
            int i;

            RleReader rleReader = new RleReader(fileStream);

            try
            {
                if (imgBpp == 1)
                {
                    int b, p;
                    byte val;
                    byte[] scanline = new byte[bytesPerLine];
                    byte[] realscanline = new byte[bytesPerLine * 8];

                    for (y = 0; y < imgH; y++)
                    {
                        Array.Clear(realscanline, 0, realscanline.Length);
                        for (p = 0; p < numPlanes; p++)
                        {
                            x = 0;
                            for (i = 0; i < bytesPerLine; i++)
                            {
                                scanline[i] = (byte)rleReader.ReadByte();
                                for (b = 7; b >= 0; b--)
                                {
                                    if ((scanline[i] & (1 << b)) != 0)
                                    {
                                        val = 1;
                                    }
                                    else
                                    {
                                        val = 0;
                                    }
                                    realscanline[x] |= (byte)(val << p);
                                    x++;
                                }
                            }
                        }
                        for (x = 0; x < imgW; x++)
                        {
                            i = realscanline[x];

                            if (numPlanes == 1)
                            {
                                bmpData[4 * (y * imgW + x)] = (byte)((i & 1) != 0 ? 0xFF : 0);
                                bmpData[4 * (y * imgW + x) + 1] = (byte)((i & 1) != 0 ? 0xFF : 0);
                                bmpData[4 * (y * imgW + x) + 2] = (byte)((i & 1) != 0 ? 0xFF : 0);
                            }
                            else
                            {
                                //if (bitPlanesLiteral)
                                //{
                                //    bmpData[4 * (y * imgW + x)] = (byte)((i & 1) != 0 ? 0xFF : 0);
                                //    bmpData[4 * (y * imgW + x) + 1] = (byte)((i & 2) != 0 ? 0xFF : 0);
                                //    bmpData[4 * (y * imgW + x) + 2] = (byte)((i & 4) != 0 ? 0xFF : 0);
                                //}
                                //else
                                //{
                                bmpData[4 * (y * imgW + x)] = colorPalette[i * 3 + 2];
                                bmpData[4 * (y * imgW + x) + 1] = colorPalette[i * 3 + 1];
                                bmpData[4 * (y * imgW + x) + 2] = colorPalette[i * 3];
                                //}
                            }
                        }
                    }
                }
                else
                {
                    if (numPlanes == 1)
                    {
                        if (imgBpp == 8)
                        {
                            byte[] scanline = new byte[bytesPerLine];
                            for (y = 0; y < imgH; y++)
                            {
                                for (i = 0; i < bytesPerLine; i++)
                                {
                                    scanline[i] = (byte)rleReader.ReadByte();
                                }
                                for (x = 0; x < imgW; x++)
                                {
                                    i = scanline[x];
                                    bmpData[4 * (y * imgW + x)] = colorPalette[i * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[i * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[i * 3];
                                }
                            }
                        }
                        else if (imgBpp == 4)
                        {
                            byte[] scanline = new byte[bytesPerLine];
                            for (y = 0; y < imgH; y++)
                            {
                                for (i = 0; i < bytesPerLine; i++)
                                {
                                    scanline[i] = (byte)rleReader.ReadByte();
                                }
                                for (x = 0; x < imgW; x++)
                                {
                                    i = scanline[x / 2];
                                    bmpData[4 * (y * imgW + x)] = colorPalette[((i >> 4) & 0xF) * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[((i >> 4) & 0xF) * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[((i >> 4) & 0xF) * 3];
                                    x++;
                                    bmpData[4 * (y * imgW + x)] = colorPalette[(i & 0xF) * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[(i & 0xF) * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[(i & 0xF) * 3];
                                }
                            }
                        }
                        else if (imgBpp == 2)
                        {
                            byte[] scanline = new byte[bytesPerLine];
                            for (y = 0; y < imgH; y++)
                            {
                                for (i = 0; i < bytesPerLine; i++)
                                    scanline[i] = (byte)rleReader.ReadByte();

                                for (x = 0; x < imgW; x++)
                                {
                                    i = scanline[x / 4];
                                    bmpData[4 * (y * imgW + x)] = colorPalette[((i >> 6) & 0x3) * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[((i >> 6) & 0x3) * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[((i >> 6) & 0x3) * 3];
                                    x++;
                                    bmpData[4 * (y * imgW + x)] = colorPalette[((i >> 4) & 0x3) * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[((i >> 4) & 0x3) * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[((i >> 4) & 0x3) * 3];
                                    x++;
                                    bmpData[4 * (y * imgW + x)] = colorPalette[((i >> 2) & 0x3) * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[((i >> 2) & 0x3) * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[((i >> 2) & 0x3) * 3];
                                    x++;
                                    bmpData[4 * (y * imgW + x)] = colorPalette[(i & 0x3) * 3 + 2];
                                    bmpData[4 * (y * imgW + x) + 1] = colorPalette[(i & 0x3) * 3 + 1];
                                    bmpData[4 * (y * imgW + x) + 2] = colorPalette[(i & 0x3) * 3];
                                }
                            }
                        }
                    }
                    else if (numPlanes == 3)
                    {
                        byte[] scanlineR = new byte[bytesPerLine];
                        byte[] scanlineG = new byte[bytesPerLine];
                        byte[] scanlineB = new byte[bytesPerLine];
                        int bytePtr = 0;

                        for (y = 0; y < imgH; y++)
                        {
                            for (i = 0; i < bytesPerLine; i++)
                                scanlineR[i] = (byte)rleReader.ReadByte();
                            for (i = 0; i < bytesPerLine; i++)
                                scanlineG[i] = (byte)rleReader.ReadByte();
                            for (i = 0; i < bytesPerLine; i++)
                                scanlineB[i] = (byte)rleReader.ReadByte();

                            for (int n = 0; n < imgW; n++)
                            {
                                bmpData[bytePtr++] = scanlineB[n];
                                bmpData[bytePtr++] = scanlineG[n];
                                bmpData[bytePtr++] = scanlineR[n];
                                bytePtr++;
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Chyba: " + e.Message);
            }

            bitMap = new Bitmap((int)imgW, (int)imgH, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            System.Drawing.Imaging.BitmapData bmpBits = bitMap.LockBits(new Rectangle(0, 0, bitMap.Width, bitMap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            System.Runtime.InteropServices.Marshal.Copy(bmpData, 0, bmpBits.Scan0, imgW * 4 * imgH);
            bitMap.UnlockBits(bmpBits);
            return bitMap;
        }
    }
}
