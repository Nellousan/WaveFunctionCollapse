using Godot;
using System;

public class WaveFunctionCollapseScene : Control
{

    private TextureRect _inputTexture;
    private VBoxContainer _inputsButtons;
    private HFlowContainer _patterns;
    private LineEdit _n;
    private Button _generateButton;
    private TextureRect _resultTexture;

    public override void _Ready()
    {
        _inputTexture = GetNode<TextureRect>("HBoxContainer/Input/Input/Texture");
        _inputsButtons = GetNode<VBoxContainer>("HBoxContainer/Input/Input/InputsFolder/VBoxContainer");

        _patterns = GetNode<HFlowContainer>("HBoxContainer/Input/Patterns/HFlowContainer");
        
        _n = GetNode<LineEdit>("HBoxContainer/PanelContainer/HFlowContainer/NEdit");
        _generateButton = GetNode<Button>("HBoxContainer/PanelContainer/HFlowContainer/GenerateButton");

        _resultTexture = GetNode<TextureRect>("HBoxContainer/PanelContainer/HFlowContainer/Result");

        openTexturesDirectory();
    }

    private void openTexturesDirectory()
    {
        var dir = new Directory();

        dir.Open("res://textures");

        dir.ListDirBegin();

        var fileName = dir.GetNext();

        while (fileName != "") {
            if (!dir.CurrentIsDir()) {
                Button button = new Button();
                button.Text = fileName;
                _inputsButtons.AddChild(button);
            }
            fileName = dir.GetNext();
        }
    }
}
