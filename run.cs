private void sendEmailButton_Click(object sender, EventArgs e)
{
    try
    {
        // Önce CV'yi e-posta olarak gönderin
        var smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("gonderen@gmail.com", "sifre"),
            EnableSsl = true
        };
        var cvMessage = new MailMessage
        {
            From = new MailAddress("gonderen@gmail.com"),
            Subject = "CV",
            Body = $"Merhaba,\n\n{firstNameTextBox.Text} {lastNameTextBox.Text} adlı kişinin CV'si ekte yer almaktadır.\n\nSaygılarımla,\nGönderen"
        };
        cvMessage.To.Add("alici@gmail.com");
        var cvAttachment = new Attachment("cv.pdf");
        cvMessage.Attachments.Add(cvAttachment);
        smtpClient.Send(cvMessage);
        MessageBox.Show("CV e-posta olarak gönderildi.");

        // Ardından kapak yazısı ve portföy dosyalarını e-posta olarak gönderin
        var coverLetterMessage = new MailMessage
        {
            From = new MailAddress("gonderen@gmail.com"),
            Subject = "Kapak Yazısı",
            Body = $"Merhaba,\n\n{firstNameTextBox.Text} {lastNameTextBox.Text} adlı kişinin kapak yazısı ekte yer almaktadır.\n\nSaygılarımla,\nGönderen"
        };
        coverLetterMessage.To.Add("alici@gmail.com");
        var coverLetterAttachment = new Attachment("kapak.pdf");
        coverLetterMessage.Attachments.Add(coverLetterAttachment);
        smtpClient.Send(coverLetterMessage);
        MessageBox.Show("Kapak yazısı e-posta olarak gönderildi.");

        var portfolioMessage = new MailMessage
        {
            From = new MailAddress("gonderen@gmail.com"),
            Subject = "Portföy",
            Body = $"Merhaba,\n\n{firstNameTextBox.Text} {lastNameTextBox.Text} adlı kişinin portföyü ekte yer almaktadır.\n\nSaygılarımla,\nGönderen"
        };
        portfolioMessage.To.Add("alici@gmail.com");
        var portfolioAttachment = new Attachment("portfoy.pdf");
        portfolioMessage.Attachments.Add(portfolioAttachment);
        smtpClient.Send(portfolioMessage);
        MessageBox.Show("Portföy e-posta olarak gönderildi.");
    }
    catch (Exception ex)
    {
        MessageBox.Show("E-posta gönderme hatası: " + ex.Message);
    }
}
