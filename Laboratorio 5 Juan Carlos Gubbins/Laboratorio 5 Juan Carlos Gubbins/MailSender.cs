using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Laboratorio_5_Juan_Carlos_Gubbins
{
    public class MailSender
    {
        public delegate void EmailSendEventHandler(object source, EmailSendEventArgs args);
        public event EmailSendEventHandler EmailSended;
        protected virtual void OnEmailSended()
        {
            if( EmailSended != null)
            {
                EmailSended(this, new EmailSendEventArgs());
            }

        }

        public void OnRegistered(object source, RegisterEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}: \n Gracias por registrarte, {e.Username}!\n Por favor, para poder verificar tu correo, has click en: {e.VerificationLink}\n");
            Thread.Sleep(2000);
            OnEmailSended();
        }

        public void OnPasswordChanged(object source, ChangePasswordEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}:  \n {e.Username}, te notificamos que la contrasena de tu cuenta PlusCorp ha sido cambiada. \n");
            Thread.Sleep(2000);
        }

    }
}