﻿using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Graphics
{
    public static class Utils
    {
        public static void ScreenCapture(Window win, string savepath)
        {
            // taking a picture of a viewport
            byte[,,] img = new byte[win.Height, win.Width, 3];
            GL.ReadPixels(0, 0, win.Width, win.Height, PixelFormat.Rgb, PixelType.UnsignedByte, img);

            var bitmap = new System.Drawing.Bitmap(win.Width, win.Height);
            for (int i = 0; i < win.Height; i++)
            {
                for (int j = 0; j < win.Width; j++)
                {
                    bitmap.SetPixel(j, win.Height - 1 - i, System.Drawing.Color.FromArgb(img[i, j, 0], img[i, j, 1], img[i, j, 2]));
                }
            }

            // saving captured image
            bitmap.Save(savepath + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public static float[] GL_Convert(System.Numerics.Vector3[] data, Color4 color)
        {
            // converting program data to OpenGL buffer format
            float[] res = new float[data.Length * 7];

            for (int i = 0; i < data.Length; i++)
            {
                res[7 * i] = data[i].X;
                res[7 * i + 1] = data[i].Y;
                res[7 * i + 2] = data[i].Z;
                res[7 * i + 3] = color.R;
                res[7 * i + 4] = color.G;
                res[7 * i + 5] = color.B;
                res[7 * i + 6] = color.A;
            }

            return res;
        }
    }
}
