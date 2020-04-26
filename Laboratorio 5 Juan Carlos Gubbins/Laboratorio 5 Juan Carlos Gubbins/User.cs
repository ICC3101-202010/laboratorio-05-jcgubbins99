using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_5_Juan_Carlos_Gubbins
{
    public class User : MailSender
    {
        public delegate void EmailVerifiedEventHandler(object source, EmailVerifiedEventArgs args);
        public event EmailVerifiedEventHandler EmailVerified;
        protected virtual void OnEmailVerified()
        {
            if (EmailVerified != null)
            {
                EmailVerified(this, new EmailVerifiedEventArgs());
            }

        }

        public void OnEmailSent(object source, EmailSendEventArgs es)
        {
            Console.WriteLine("¿Desea verificar su mail?");
            Console.WriteLine("1.SI");
            Console.WriteLine("2.NO");
            string accion = null;
            while (accion != "2" && accion != "1")
            {

                accion = Console.ReadLine();
                switch (accion)
                {
                    case "1":
                        //Disparamos el evento
                        OnEmailVerified();
                        break;
                    case "2":
                        Console.WriteLine("=====================");
                        Console.WriteLine("Has elegido no verificar el mail");
                        Console.WriteLine("=====================");
                        break;
                    default:
                        Console.WriteLine("No se ha seleccionado ninguna opción válida");
                        break;
                }
            }
        }
                
             

    }
}
