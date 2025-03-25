using Microsoft.Maui.Handlers;
using UIKit;

namespace NativeForms.Handlers;

public partial class NativePickerHandler : ViewHandler<Picker, UIButton>
{
    public static readonly IPropertyMapper<IPicker, NativePickerHandler> PropertyMapper
        = new PropertyMapper<IPicker, NativePickerHandler>(ViewMapper)
        {
            [nameof(IPicker.SelectedIndex)] = MapSelectedIndex,
            [nameof(IPicker.Items)] = MapItems,
            [nameof(IPicker.Title)] = MapTitle
        };

    public NativePickerHandler() : base(PropertyMapper)
    {
    }

    protected override UIButton CreatePlatformView()
    {
        var button = new UIButton(UIButtonType.System)
        {
            ShowsMenuAsPrimaryAction = true,
            ChangesSelectionAsPrimaryAction = true
        };

        button.SetTitle("Select an option", UIControlState.Normal);

        return button;
    }

    protected override void ConnectHandler(UIButton platformView)
    {
        base.ConnectHandler(platformView);
        UpdateTitle();
    }

    private void OnItemSelected(int index)
    {
        VirtualView.SelectedIndex = index;
        UpdateTitle();
    }

    private void UpdateTitle()
    {
        if (VirtualView.SelectedIndex >= 0 && VirtualView.SelectedIndex < VirtualView.Items.Count)
        {
            PlatformView.SetTitle(VirtualView.Items[VirtualView.SelectedIndex], UIControlState.Normal);
        }
        else
        {
            PlatformView.SetTitle(VirtualView.Title ?? "Select an option", UIControlState.Normal);
        }
    }

    protected override void DisconnectHandler(UIButton platformView)
    {
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    // Mapper callbacks to update the platform view when properties change.
    public static void MapSelectedIndex(NativePickerHandler handler, IPicker view)
    {
        handler.UpdateTitle();
    }

    public static void MapItems(NativePickerHandler handler, IPicker view)
    {
        handler.UpdateTitle();

        if (view.Items == null || view.Items.Count == 0)
        {
            handler.PlatformView.Menu = null;
            return;
        }

        // Create an array of UIActions from the picker items.
        var actions = view.Items.Select((item, index) =>
            UIAction.Create(item, null, null, action => handler.OnItemSelected(index))).ToArray();

        handler.PlatformView.Menu = UIMenu.Create(actions);
    }

    public static void MapTitle(NativePickerHandler handler, IPicker view)
    {
        handler.UpdateTitle();
    }
}
