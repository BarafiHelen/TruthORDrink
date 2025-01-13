using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthORDrink.MVVM.Models
{
    public class QRManager
    {
        public string QRCodeData { get; set; }

        public string GenerateQRCode()
        {
            // Logica om een QR-code te genereren
            QRCodeData = "QR Code gegenereerd";
            return QRCodeData;
        }

        public QRManager()
        {

        }

        public bool ValidateQRCode(string qrCodeData)
        {
            // Logica om een QR-code te valideren
            return qrCodeData == QRCodeData;
        }
    }
}
