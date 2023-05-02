private void sendEmailButton_Click(object sender, EventArgs e)
{
    try
    {
        var smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("gonderen@gmail.com", "sifre"),
            EnableSsl = true
        };
        var mailMessage = new MailMessage
        {
            From = new MailAddress("gonderen@gmail.com"),
            Subject = "CV",
            Body = $"Merhaba,\n\n{firstNameTextBox.Text} {lastNameTextBox.Text} adlı kişinin CV'si ekte yer almaktadır.\n\nSaygılarımla,\nGönderen"
        };
        mailMessage.To.Add("alici@gmail.com");
        var attachment = new Attachment("cv.pdf");
        mailMessage.Attachments.Add(attachment);
        smtpClient.Send(mailMessage);
        MessageBox.Show("CV e-posta olarak gönderildi.");
    }
    catch (Exception ex)
    {
        MessageBox.Show("CV gönderme hatası: " + ex.Message);
    }
}
