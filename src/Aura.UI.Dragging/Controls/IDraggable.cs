﻿using Avalonia.Controls;
using Avalonia.LogicalTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging.Controls
{
    public interface IDraggable : IControl, ILogical
    {
        public event EventHandler<AuraDragEventArgs> DragStarted;
        public event EventHandler<AuraDragEventArgs> DragDelta;
        public event EventHandler<AuraDragEventArgs> DragLeave;
        public event EventHandler<AuraDragEventArgs> Drop;
    }
}
