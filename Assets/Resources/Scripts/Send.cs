using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
//using System.Net.Mail; //doesnt work on web
using System.Collections;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
//TestingUnity3DEmail
public class Send: MonoBehaviour 
{
	//private int score = 0;
	//private static string user = "name";
	public GameObject userEnter;
	public Text score;
	
	void Start()
	{

	}
	public void SendEmailF()
	{
		/*user = userEnter.GetComponent<InputField>().text;
		MailMessage mail = new MailMessage();
		
		mail.From = new MailAddress("irbgame@gmail.com");
		mail.To.Add("irbgame@gmail.com");
		mail.Subject = "   Score of " + user + DateTime.Now.ToString("    ddd MMM  d HH:mm");
		mail.Body = "This was generated automatically";

		//Attach File from Memory
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
			writer.Write(user + "\n" + score.text);
			writer.Flush();
			ms.Position = 0;
			
			System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
			System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
			attach.ContentDisposition.FileName = "myFile.txt";

		mail.Attachments.Add(attach);

		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("irbgame@gmail.com", "UROPscore") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		};

		smtpServer.Send(mail);
		//Debug.Log("success");*/
	}


}