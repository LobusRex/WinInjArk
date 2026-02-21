namespace WinInjArk.Forms;

// Is this good?
public interface IFormFactory<TForm> where TForm : Form
{
    TForm Create(IServiceProvider serviceProvider);
}
