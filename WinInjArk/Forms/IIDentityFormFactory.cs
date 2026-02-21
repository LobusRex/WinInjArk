namespace WinInjArk.Forms;

public interface IIDentityFormFactory<TForm> where TForm : Form
{
    TForm Create(
        IServiceProvider serviceProvider,
        FormIdentity formIdentity);
}
