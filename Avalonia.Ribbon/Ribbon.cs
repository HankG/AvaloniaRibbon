﻿using Avalonia.Collections;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections;

namespace Avalonia.Controls.Ribbon
{
    public class Ribbon : TabControl, IStyleable
    {
        private IEnumerable _menuItems = new AvaloniaList<object>();
        private IEnumerable _menuPlacesItems = new AvaloniaList<object>();

        public IEnumerable MenuItems
        {
            get { return _menuItems; }
            set { SetAndRaise(MenuItemsProperty, ref _menuItems, value); }
        }

        public IEnumerable MenuPlacesItems
        {
            get { return _menuPlacesItems; }
            set { SetAndRaise(MenuPlacesItemsProperty, ref _menuPlacesItems, value); }
        }

        public static readonly StyledProperty<IBrush> RemainingTabControlHeaderColorProperty;
        public static readonly StyledProperty<bool> IsCollapsedProperty;
        public static readonly StyledProperty<bool> IsMenuOpenProperty;
        public static readonly DirectProperty<Ribbon, IEnumerable> MenuItemsProperty;
        public static readonly DirectProperty<Ribbon, IEnumerable> MenuPlacesItemsProperty;

        static Ribbon()
        {
            RemainingTabControlHeaderColorProperty = AvaloniaProperty.Register<Ribbon, IBrush>(nameof(RemainingTabControlHeaderColor));
            IsCollapsedProperty = AvaloniaProperty.Register<Ribbon, bool>(nameof(IsCollapsed));
            IsMenuOpenProperty = AvaloniaProperty.Register<Ribbon, bool>(nameof(IsMenuOpen));
            MenuItemsProperty = MenuBase.ItemsProperty.AddOwner<Ribbon>(x => x.MenuItems, (x, v) => x.MenuItems = v);
            MenuPlacesItemsProperty = ItemsControl.ItemsProperty.AddOwner<Ribbon>(x => x.MenuPlacesItems, (x, v) => x.MenuPlacesItems = v);
        }

        Type IStyleable.StyleKey => typeof(Ribbon);

        public bool IsCollapsed
        {
            get => GetValue(IsCollapsedProperty);
            set => SetValue(IsCollapsedProperty, value);
        }

        public bool IsMenuOpen
        {
            get => GetValue(IsMenuOpenProperty);
            set => SetValue(IsMenuOpenProperty, value);
        }

        public IBrush RemainingTabControlHeaderColor
        {
            get { return GetValue(RemainingTabControlHeaderColorProperty); }
            set { SetValue(RemainingTabControlHeaderColorProperty, value); }
        }

        protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
        {
            if (ItemCount > 1)
            {
                if (e.Delta.Y > 0)
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                }
                else if (e.Delta.Y < 0)
                {
                    if (SelectedIndex < (ItemCount - 1))
                        SelectedIndex++;
                }
            }
            base.OnPointerWheelChanged(e);
        }
    }
}