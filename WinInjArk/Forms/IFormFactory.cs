namespace WinInjArk.Forms;

// Is this good?
// Do we need another one for forms with identity?
public interface IFormFactory<TForm> where TForm : Form
{
    TForm Create(IServiceProvider serviceProvider);
}
