using Memento.TextEditorApp;
class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        editor.DisplayDocument();

        editor.SetContent("Let's go into the woods Oleksandr Sushko");
        editor.SetFontName("Times New Roman");
        editor.SetFontSize(14);
        editor.SaveState();
        editor.DisplayDocument();

        editor.SetContent("New changed content, Oleksandr Sushko doesn't accept invitation T_T");
        editor.ToggleBold();
        editor.SaveState();
        editor.DisplayDocument();

        editor.DisplayHistory();

        editor.Undo();
        editor.DisplayDocument();

        editor.Undo();
        editor.DisplayDocument();

        editor.Redo();
        editor.DisplayDocument();

        editor.DisplayHistory();
    }
}