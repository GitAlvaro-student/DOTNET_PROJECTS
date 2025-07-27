using System;

internal interface INotificavel
{
	void Notificar(string mensagem);
}
internal class Email: INotificavel
{
	public void Notificar(string mensagem)
	{
		Console.WriteLine($"Enviando email com a mensagem: {mensagem}");
	}
}
internal class SMS: INotificavel
{
	public void Notificar(string mensagem)
	{
		Console.WriteLine($"Enviando SMS com a mensagem: {mensagem}");
	}
}
