using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;



    public static  class utilty
    {

    public static string ToLowerFirst(this string str)
    {
        return str.Substring(0, 1).ToLower() + str.Substring(1);
    }

    public static string ConvertNumbersToPersian(this string str)
    {
        return str.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
    }

    public static string ConvertNumbersToEnglish(this string str)
    {
        return str.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
    }

    public enum ImageComperssion
    {
        Maximum = 50,
        Good = 60,
        Normal = 70,
        Fast = 80,
        Minimum = 90,
    }

    public static void ResizeImage(this Stream inputStream, int width, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
    {
        System.Drawing.Image img = new Bitmap(inputStream);
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
        result.CompressImage(savePath, ic);
    }

    public static void ResizeImage(this System.Drawing.Image img, int width, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
    {
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
        result.CompressImage(savePath, ic);
    }

    public static void ResizeImageByWidth(this Stream inputStream, int width, string savePath, ImageComperssion ic = ImageComperssion.Normal)
    {
        System.Drawing.Image img = new Bitmap(inputStream);
        int height = img.Height * width / img.Width;
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
        result.CompressImage(savePath, ic);
    }

    public static void ResizeImageByWidth(this System.Drawing.Image img, int width, string savePath, ImageComperssion ic = ImageComperssion.Normal)
    {
        int height = img.Height * width / img.Width;
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
        result.CompressImage(savePath, ic);
    }

    public static void ResizeImageByHeight(this Stream inputStream, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
    {
        System.Drawing.Image img = new Bitmap(inputStream);
        int width = img.Width * height / img.Height;
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
        result.CompressImage(savePath, ic);
    }

    public static void ResizeImageByHeight(this System.Drawing.Image img, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
    {
        int width = img.Width * height / img.Height;
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
        result.CompressImage(savePath, ic);
    }

    public static void CompressImage(this System.Drawing.Image img, string path, ImageComperssion ic)
    {
        System.Drawing.Imaging.EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt32(ic));
        ImageFormat format = img.RawFormat;
        ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == format.Guid);
        string mimeType = codec == null ? "image/jpeg" : codec.MimeType;
        ImageCodecInfo jpegCodec = null;
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        for (int i = 0; i < codecs.Length; i++)
        {
            if (codecs[i].MimeType == mimeType)
            {
                jpegCodec = codecs[i];
                break;
            }
        }
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;
        img.Save(path, jpegCodec, encoderParams);
    }


    public static byte[] ResizeImage(this Stream inputStream, int width, int height, ImageComperssion ic = ImageComperssion.Normal)
    {
        System.Drawing.Image img = new Bitmap(inputStream);
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }



     //   return (Byte[])new ImageConverter().ConvertTo(img, typeof(Byte[]));
        return result.CompressImage( ic);
    }
    public static byte[] ResizeImageByHeight(this Stream inputStream, int height, ImageComperssion ic = ImageComperssion.Normal)
    {
        System.Drawing.Image img = new Bitmap(inputStream);
        int width = img.Width * height / img.Height;
        System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, 0, 0, width, height);
        }
       return result.CompressImage(ic);
    }

    public static byte[] CompressImage(this System.Drawing.Image img, ImageComperssion ic)
    {
        System.Drawing.Imaging.EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt32(ic));
        ImageFormat format = img.RawFormat;
        ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == format.Guid);
        string mimeType = codec == null ? "image/jpeg" : codec.MimeType;
        ImageCodecInfo jpegCodec = null;
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        for (int i = 0; i < codecs.Length; i++)
        {
            if (codecs[i].MimeType == mimeType)
            {
                jpegCodec = codecs[i];
                break;
            }
        }
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        Byte[] result = (Byte[])new ImageConverter().ConvertTo(img, typeof(Byte[]));



        MemoryStream ms = new MemoryStream();
        img.Save(ms, ImageFormat.Bmp);
        byte[] bitmapData = ms.ToArray();

        MemoryStream mstImage = new MemoryStream();
        img.Save(mstImage, System.Drawing.Imaging.ImageFormat.Jpeg);
        Byte[] bytImage = mstImage.GetBuffer();
       

        using (var stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            var uu= stream.ToArray();
        }



        return bytImage;
    }


}
