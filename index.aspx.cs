using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string docupath = Request.PhysicalApplicationPath; //抓取實際目錄路徑
        if (TextBox1.Text != "") //判斷使用者輸入
        {
            String xcontent = TextBox1.Text;
            String xtime = DateTime.Now.Millisecond.ToString(); //取得當亂數            
            Label1.Text = "qrcode_" + xtime + ".png"; //顯示檔名
            QRCodeEncoder xencoder = new QRCodeEncoder(); //建立 encoder
            System.Drawing.Bitmap qrcode = xencoder.Encode(xcontent); //將內容轉碼成 QR code
            qrcode.Save(docupath + "images\\qrcode_" + xtime + ".png"); //把 QRcode 另存為 PNG 圖檔,並放置於 images 資料夾底下
            Image1.ImageUrl = "~\\images\\qrcode_" + xtime + ".png"; //設定組件 Image 的來源
        }
        else // textbox 沒內容就不轉 QRcode + 提示訊息
        {
            Label1.Text = "請輸入資料!!";
        }
    }
}
