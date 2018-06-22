## Context

#### nk.init()
Initialize the library. This must be called before any of the other functions.

#### nk.shutdown()
Close the library, freeing all associated resources. A subsequent call to `nk.init` is required before using any other functions.

***

## Event

#### consumed = nk.keypressed(key, scancode, isrepeat)
Pass the given key press event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.keypressed](https://love2d.org/wiki/love.keypressed).

#### consumed = nk.keyreleased(key, scancode)
Pass the given key release event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.keyreleased](https://love2d.org/wiki/love.keyreleased).

#### consumed = nk.mousepressed(x, y, button, istouch)
Pass the given mouse press event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.mousepressed](https://love2d.org/wiki/love.mousepressed).

#### consumed = nk.mousereleased(x, y, button, istouch)
Pass the given mouse release event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.mousereleased](https://love2d.org/wiki/love.mousereleased).

#### consumed = nk.mousemoved(x, y, dx, dy, istouch)
Pass the given mouse move event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.mousemoved](https://love2d.org/wiki/love.mousemoved).

#### consumed = nk.textinput(text)
Pass the given text input event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.textinput](https://love2d.org/wiki/love.textinput).

#### consumed = nk.wheelmoved(x, y)
Pass the given wheel move event to the UI, returning `true` if the event is consumed and `false` otherwise.

See [love.wheelmoved](https://love2d.org/wiki/love.wheelmoved).

***

## Render

#### nk.draw()
Draw the UI. Call this once every [love.draw](https://love2d.org/wiki/love.draw).

***

## Update

#### nk.frameBegin()
Begin a new frame for the UI. Call this once every [love.update](https://love2d.org/wiki/love.update), before other UI calls.

#### nk.frameEnd()
End the current frame. Call this once every [love.update](https://love2d.org/wiki/love.update), after other UI calls.

***

## Window

#### open = nk.windowBegin(title, x, y, width, height, [flags](#flags)...)
#### open = nk.windowBegin(name, title, x, y, width, height, [flags](#flags)...)
Create or update a window with the given `name`. The `name` is a unique identifier used internally to differentiate between windows. If unspecified, the `name` defaults to the `title`. The `x`, `y`, `width`, and `height` parameters describe the window's initial bounds. All additional arguments are interpreted as window [flags](#flags).

Returns `true` if the window is open and `false` if it is closed or collapsed.

#### nk.windowEnd()
End a window. This must always be called after `nk.windowBegin`, regardless of whether or not the window is open.

#### x, y, width, height = nk.windowGetBounds()
Return the bounds of the current window.

#### x, y = nk.windowGetPosition()
Return the position of the current window.

#### width, height = nk.windowGetSize()
Return the size of the current window.

#### x, y, width, height = nk.windowGetContentRegion()
Return the bounds of the current window's content region.

#### focused = nk.windowHasFocus()
Return `true` if the current window is focused, and `false` otherwise.

#### collapsed = nk.windowIsCollapsed(name)
Return 'true' if the given window is collapsed, and `false` otherwise.

#### hidden = nk.windowIsHidden(name)
Return 'true' if the given window is hidden, and `false` otherwise.

#### active = nk.windowIsActive(name)
Return `true` if the given window is active, and `false` otherwise.

#### hovered = nk.windowIsHovered()
Return `true` if the current window is hovered by the mouse, and `false` otherwise.

#### hovered = nk.windowIsAnyHovered()
Return `true` if any window is hovered by the mouse, and `false` otherwise.

#### active = nk.itemIsAnyActive()
Return `true` if any item is active, and `false` otherwise.

#### nk.windowSetBounds(x, y, width, height)
Set the bounds of the current window.

#### nk.windowSetPosition(x, y)
Set the position of the current window.

#### nk.windowSetSize(width, height)
Set the size of the current window.

#### nk.windowSetFocus(name)
Focus on the given window.

#### nk.windowClose(name)
Close the given window.

#### nk.windowCollapse(name)
Collapse the given window.

#### nk.windowExpand(name)
Expand the given window.

#### nk.windowShow(name)
Show the given window.

#### nk.windowHide(name)
Hide the given window.

### Flags
Windows and some window-like widgets can accept a number of window flags. Here is a list of the possible flags alongside their meanings:

##### 'border'
Draw a border around the window.

##### 'movable'
The window can be moved by dragging the header.

##### 'scalable'
The window can be scaled by dragging the corner.

##### 'closable'
The window can be closed by clicking the close button.

##### 'minimizable'
The window can be collapsed by clicking the minimize button.

##### 'scrollbar'
Include a scrollbar for the window.

##### 'title'
Display the window title on the header.

##### 'scroll auto hide'
Automatically hide the scrollbar after a period of inactivity.

##### 'background'
Keep the window behind all other windows.

***

## Layout

#### nk.layoutRow('dynamic', height, cols)
#### nk.layoutRow('dynamic', height, ratios)
#### nk.layoutRow('static', height, itemWidth, cols)
#### nk.layoutRow('static', height, sizes)
Adopt a row layout for the proceeding widgets.

If the layout is `'dynamic'`, the row height and columns must be specified. If `cols` is a number, it specifies the number of equally sized columns to divide the row into. If there is a `ratios` table instead, the table is treated as an array of ratios from 0 to 1. Each ratio describes the width of the column with respect to the total row width.

If the layout is `'static'`, there must either be `itemWidth` and `cols` parameters describing the number of fixed-width columns to divide the row into, or there must be a `sizes` table, which is an array of fixed widths for the columns.

Examples:
```lua
-- Create a row which is 30 pixels high and is divided into 3 equally sized columns.
nk.layoutRow('dynamic', 30, 3)

-- Create a row which is 25 pixels high and divided into two columns with a size ratio of 1:3.
nk.layoutRow('dynamic', 25, {0.25, 0.75})

-- Create a row which is 120 pixels high and is divided into 3 columns, each of width 20.
nk.layoutRow('static', 120, 20, 3)

-- Create a row which is 40 pixels high and is divided into two columns, one 20 pixels wide and the other 30 pixels.
nk.layoutRow('static', 40, {20, 30})
```

#### nk.layoutRowBegin('dynamic'/'static', height, cols)
Adopt a row layout of the specified format type, height, and column count. Before each proceeding widget, call `nk.layoutRowPush` to set the column size. Don't forget to end the layout with `nk.layoutRowEnd`.

#### nk.layoutRowPush(ratio)
#### nk.layoutRowPush(size)
Specify the width of the next widget in a row layout started with `nk.layoutRowBegin`. If the layout is dynamic, the width is specified as a ratio of the total row width from 0 to 1. If the layout is static, the width is specified as a number of pixels.

#### nk.layoutRowEnd()
Call after `nk.layoutRowBegin` in order to properly end the row layout.

#### nk.layoutSpaceBegin('dynamic'/'static', height, widgetCount)
Start a space layout with the given height and widget count. Call `nk.layoutSpacePush` before each proceeding widget and `nk.layoutSpaceEnd` after the layout is finished.

#### nk.layoutSpacePush(x, y, width, height)
Specify the bounds of a widget in a space layout. If the layout is dynamic, the bounds are specified as ratios from 0 to 1 of the total width and height of the space layout. If the layout is static, the bounds are pixel valued offsets from the beginning of the layout.

#### nk.layoutSpaceEnd()
End a space layout.

#### x, y, width, height = nk.layoutSpaceBounds()
Return the bounds of the current space layout.

#### x, y nk.layoutSpaceToScreen(x, y)
Convert a space layout local position to global screen position.

#### x, y = nk.layoutSpaceToLocal(x, y)
Convert a global screen position to space layout local position.

#### x, y, width, height = nk.layoutSpaceRectToScreen(x, y, width, height)
Convert space layout local bounds to global screen bounds.

#### x, y, width, height = nk.layoutSpaceRectToLocal(x, y, width, height)
Convert global screen bounds to space layout local bounds.

#### ratio = nk.layoutRatioFromPixel(pixelWidth)
Convert a pixel width to a ratio suitable for a dynamic layout.

***

## Widgets

### Groups

#### open = nk.groupBegin(title, [flags](#flags)...)
Start a group. Groups can have titles and scrollbars just like windows.

Return `true` if the group is open and `false` otherwise.

Call `nk.groupEnd` at the end of a group if it's open.

#### nk.groupEnd()
End a group. Remember to call this whenever the group is open.

### Trees

#### open = nk.treePush('node'/'tab', title)
#### open = nk.treePush('node'/'tab', title, image)
#### open = nk.treePush('node'/'tab', title, image, 'collapsed'/'expanded')
Start a tree. The resulting item is either a `'node'` or a `'tab'`, with the idea being that nodes are a level below tabs. Optionally specify an image (default is none) or a starting state (default is `'collapsed'`).

Return `true` if the item is expanded, and `false` if it is collapsed.

Remember to call `nk.treePop` if the item is open.

#### nk.treePop()
Ends a tree. Call this at the end of an open tree item.

### Popups

#### open = nk.popupBegin('dynamic'/'static', title, x, y, width, height, [flags](#flags)...)
Start a popup with the given size and [flags](#flags). Bounds can be given as either dynamic ratios or static pixel counts.

Return `true` if the popup is open, and `false` otherwise.

Call `nk.popupEnd` to end the popup if it is open.

#### nk.popupClose()
Close the current popup.

#### nk.popupEnd()
End a popup. Be sure to call this when ending an open popup.

### Context Menus

#### open = nk.contextualBegin(width, height, triggerX, triggerY, triggerWidth, triggerHeight, [flags](#flags)...)
Set up a context menu of the given size and trigger bounds. Also takes window [flags](#flags).

Return `true` if the context menu is open, and `false` otherwise.

#### activated = nk.contextualItem(text)
#### activated = nk.contextualItem(text, [symbol](#symbols)/image)
#### activated = nk.contextualItem(text, [symbol](#symbols)/image, [align](#alignment))
Add an item to a context menu. Optionally specify a [symbol](#symbols) type, image, and/or [alignment](#alignment).

Return `true` if the item is activated, and `false` otherwise.

Call `nk.contextualEnd` at the end of an open context menu.

#### nk.contextualClose()
Close the current context menu.

#### nk.contextualEnd()
End the current context menu. Be sure to call this at the end of an open context menu.

### Tooltips

#### nk.tooltip(text)
Show a tooltip with the given text.

#### open = nk.tooltipBegin(width)
Start a tooltip with the given width.

Return `true` if the tooltip is open, and `false` otherwise.

Be sure to call `nk.tooltipEnd` at the end of an open tooltip.

#### nk.tooltipEnd()
End a tooltip previously started with `nk.tooltipBegin`. Call this at the end of every open tooltip.

### Menus

#### nk.menubarBegin()
Start a menu bar. Menu bars stay at the top of a window even when scrolling. Call `nk.menubarEnd` to end one.

#### nk.menubarEnd()
Ends a menu bar. Always call this at the end of a menu bar started with `nk.menubarBegin`.

#### open = nk.menuBegin(title, [symbol](#symbols)/image, width, height)
#### open = nk.menuBegin(title, [symbol](#symbols)/image, width, height, [align](#alignment))
Start a menu of the given title and size. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).

Return `true` if the menu is open, and `false` otherwise.

Be sure to call `nk.menuEnd` when ending open menus.

#### activated = nk.menuItem(title)
#### activated = nk.menuItem(title, [symbol](#symbols)/image)
#### activated = nk.menuItem(title, [symbol](#symbols)/image, [align](#alignment))
Add a menu item to the current menu. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).

Return `true` if the menu item is activated, and `false` otherwise.

#### nk.menuClose()
Close the current menu.

#### nk.menuEnd()
End the current menu. Always call this at the end of any open menu.

### General

#### nk.label(text)
#### nk.label(text, [align](#alignment)/'wrap')
#### nk.label(text, [align](#alignment)/'wrap', [color](#colors))
Show a text string. Optionally specify an [alignment](#alignment) and/or [color](#colors).

#### nk.image(img)
Show an image.

See [LÖVE Image](https://love2d.org/wiki/Image).

#### activated = nk.button(title)
#### activated = nk.button(title, [color](#colors)/[symbol](#symbols)/image)
Add a button with a title and/or a [color](#colors), [symbol](#symbols), or image.

Return `true` if activated, and `false` otherwise.

#### nk.buttonSetBehavior('default'/'repeater')
Sets whether a button is activated once per click (`'default'`) or every frame held down (`'repeater'`).

#### nk.buttonPushBehavior('default'/'repeater')
Push button behavior.

#### nk.buttonPopBehavior()
Pop button behavior.

#### active = nk.checkbox(text, active)
#### changed = nk.checkbox(text, valueTable)
Add a checkbox with the given title. Either specify a boolean state `active`, in which case the function returns the new state, or specify a table with a boolean field called `value`, in which case the value is updated and the function returns `true` on toggled, and `false` otherwise.

#### selection = nk.radio(text, selection)
#### selection = nk.radio(name, text, selection)
#### changed = nk.radio(text, valueTable)
#### changed = nk.radio(name, text, valueTable)
Add a radio button with the given name and/or title. The title is displayed to the user while the name is used to report which button is selected. By default, the name is the same as the title.

If called with a string `selection`, the function returns the new `selection`, which should be the `name` of a radio button. If called with a table that has a string field `value`, the `value` gets updated and the function returns `true` on selection change and `false` otherwise.

#### selected = nk.selectable(text, selected)
#### selected = nk.selectable(text, image, selected)
#### selected = nk.selectable(text, image, [align](#alignment), selected)
#### changed = nk.selectable(text, valueTable)
#### changed = nk.selectable(text, image, valueTable)
#### changed = nk.selectable(text, image, [align](#alignment), valueTable)
Add a selectable item with the given text and/or image and [alignment](#alignment).

If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.

#### current = nk.slider(min, current, max, step)
#### changed = nk.slider(min, valueTable, max, step)
Add a slider widget with the given range and step size.

If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.

#### current = nk.progress(current, max)
#### current = nk.progress(current, max, modifiable)
#### changed nk.progress(valueTable, max)
#### changed = nk.progress(valueTable, max, modifiable)
Add a progress widget, optionally making it modifiable.

If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.

#### [color](#colors) = nk.colorPicker([color](#colors))
#### [color](#colors) = nk.colorPicker([color](#colors), 'RGB'/'RGBA')
#### changed = nk.colorPicker(valueTable)
#### changed = nk.colorPicker(valueTable, 'RGB'/'RGBA')
Add a color picker widget, optionally specifying format (default 'RGB', no alpha).

If given a `[color](#colors)` string, return the new `[color](#colors)`. If given a table with a [color](#colors) string field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.

#### current = nk.property(name, min, current, max, step, incPerPixel)
#### changed = nk.property(name, min, valueTable, max, step, incPerPixel)
Add a property widget, which is a named number variable. Specify the range, step, and sensitivity.

If given a number `current`, return the new `current`. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.

#### state, changed = nk.edit('simple'/'field'/'box', valueTable)
Add an editable text field widget. The first argument defines the type of editor to use: single line 'simple' and 'field', or multi-line 'box'. The `valueTable` should be a table with a string field named `value`. The field gets updated and the function returns the edit state (one of 'commited'/'activated'/'deactivated'/'active'/'inactive') followed by `true` if the text changed or `false` if the text remained the same.

#### index = nk.combobox(index, items)
#### index = nk.combobox(index, items, itemHeight)
#### index = nk.combobox(index, items, itemHeight, width)
#### index = nk.combobox(index, items, itemHeight, width, height)
#### changed = nk.combobox(valueTable, items)
#### changed = nk.combobox(valueTable, items, itemHeight)
#### changed = nk.combobox(valueTable, items, itemHeight, width)
#### changed = nk.combobox(valueTable, items, itemHeight, width, height)
Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.

If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.

#### open = nk.comboboxBegin(text)
#### open = nk.comboboxBegin(text, [color](#colors)/[symbol](#symbols)/image)
#### open = nk.comboboxBegin(text, [color](#colors)/[symbol](#symbols)/image, width)
#### open = nk.comboboxBegin(text, [color](#colors)/[symbol](#symbols)/image, width, height)
Start a combobox widget. This form gives complete control over the drop-down list (it's treated like a new window). [Color](#colors)/[symbol](#symbols)/image defaults to none, while width and height default to sensible values based on widget bounds.

Remember to call `nk.comboboxEnd` if the combobox is open.

#### activated = nk.comboboxItem(text)
#### activated = nk.comboboxItem(text, [symbol](#symbols)/image)
#### activated = nk.comboboxItem(text, [symbol](#symbols)/image, [align](#alignment))
Add a combobox item, optionally specifying a [symbol](#symbols), image, and/or [alignment](#alignment).

Return `true` if the item is activated, and `false` otherwise.

#### nk.comboboxClose()
Close the current combobox.

#### nk.comboboxEnd()
End the current combobox. Always call this at the end of open comboboxes.

### Utilities

#### x, y, width, height = nk.widgetBounds()
Return the bounds of the current widget.

#### x, y = nk.widgetPosition()
Return the position of the current widget.

#### width, height = nk.widgetSize()
Return the size of the current widget.

#### width = nk.widgetWidth()
Return the width of the current widget.

#### height = nk.widgetHeight()
Return the height of the current widget.

#### hovered = nk.widgetIsHovered()
Return `true` if the widget is hovered by the mouse, and `false` otherwise.

#### pressed = nk.widgetHasMousePressed()
#### pressed = nk.widgetHasMousePressed(button)
Return `true` if the given mouse button was pressed on the current widget and has not yet been released, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### released = nk.widgetHasMouseReleased()
#### released = nk.widgetHasMouseReleased(button)
Return `true` if the given mouse button was released on the current widget and has not since been pressed, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### pressed = nk.widgetIsMousePressed()
#### pressed = nk.widgetIsMousePressed(button)
Return `true` if the given mouse button was pressed on the current widget this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### released = nk.widgetIsMouseReleased()
#### released = nk.widgetIsMouseReleased(button)
Return `true` if the given mouse button was released on the current widget this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### nk.spacing(cols)
Empty space taking up the given number of columns.

### Symbols
Various widgets accept `symbol` type strings as parameters. Here is a complete list of symbol types:
* 'none'
* 'x'
* 'underscore'
* 'circle solid'
* 'circle outline'
* 'rect solid'
* 'rect outline'
* 'triangle up'
* 'triangle down'
* 'triangle left'
* 'triangle right'
* 'plus'
* 'minus'

### Alignment
Some widgets accept alignment arguments for text, symbols, and/or images. Here is a complete list of alignment types:
* 'left'
* 'centered'
* 'right'
* 'top left'
* 'top centered'
* 'top right'
* 'bottom left'
* 'bottom centered'
* 'bottom right'

***

## Drawing

Use the following functions to draw custom widgets. They use the current LÖVE line thickness and color.

#### nk.line(x1, y1, x2, y2, ...)
Draw a multi-segment line at the given screen coordinates.

#### nk.curve(x1, y1, crtl1x, ctrl1y, ctrl2x, ctrl2y, x2, y2)
Draw a Bézier curve with the given start, control, and end points.

#### nk.polygon('fill'/'line', x1, y1, x2, y2, x3, y3, ...)
Draw a polygon with the given draw mode and screen coordinates.

#### nk.circle('fill'/'line', x, y, r)
Draw a circle with the given draw mode, center screen coordinates, and radius.

#### nk.ellipse('fill'/'line', x, y, rx, ry)
Draw an ellipse with the given draw mode, center screen coordinates, and radii.

#### nk.arc('fill'/'line', x, y, r, startAngle, endAngle)
Draw an arc with the given draw mode, screen coordinates, radius, and angles.

#### nk.rectMultiColor(x, y, width, height, [topLeftColor](#colors), [topRightColor](#colors), [bottomLeftColor](#colors), [bottomRightColor](#colors))
Draw a gradient rectangle with the given screen coordinates, size, and corner colors.

#### nk.scissor(x, y, width, height)
Set the scissor area to the given screen coordinates and size.

#### nk.image(img, x, y, width, height)
Draw the given image at the given screen bounds.

See [LÖVE Image](https://love2d.org/wiki/Image).

#### nk.text(str, x, y, width, height)
Draw the given string at the given screen bounds.

***

## Input

#### hovered = nk.inputWasHovered(x, y, width, height)
Return `true` if the given screen bounds were hovered by the mouse in the previous frame, and `false` otherwise.

#### hovered = nk.inputIsHovered(x, y, width, height)
Return `true` if the given screen bounds are hovered by the mouse, and `false` otherwise.

#### pressed = nk.inputHasMousePressed(button, x, y, width, height)
Return `true` if the given mouse button was pressed in the given screen bounds and has not yet been released, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### released = nk.inputHasMouseReleased(button, x, y, width, height)
Return `true` if the given mouse button was released in the given screen bounds and has not since been pressed, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### pressed = nk.inputIsMousePressed(button, x, y, width, height)
Return `true` if the given mouse button was pressed in the given screen bounds this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

#### released = nk.inputIsMouseReleased(button, x, y, width, height)
Return `true` if the given mouse button was released in the given screen bounds this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').

***

## Styling

### Colors
Some styles and widgets accept a "color string" parameter. This is a string of the format '#RRGGBB' or '#RRGGBBAA', where RR, GG, BB, and AA are each a byte in hexadecimal. Either use these strings directly or convert to and from the string format via the following functions.

#### color = nk.colorRGBA(r, g, b)
#### color = nk.colorRGBA(r, g, b, a)
Construct a color string from the given components (each from 0 to 255). Alpha (`a`) defaults to 255.

#### color = nk.colorHSVA(h, s, v)
#### color = nk.colorHSVA(h, s, v, a)
Construct a color string from the given components (each from 0 to 255). Alpha (`a`) defaults to 255.

#### r, g, b, a = nk.colorParseRGBA(color)
Split a color string into its number components.

#### h, s, v, a = nk.colorParseHSVA(color)
Split a color string into its number components.

#### nk.styleDefault()
Reset color styles to their default values.

#### nk.styleLoadColors(colorTable)
Load a color table for quick color styling.

Below is the default color table. Custom color tables must provide all of the same fields.
```lua
local colorTable = {
	['text'] = '#afafaf',
	['window'] = '#2d2d2d',
	['header'] = '#282828',
	['border'] = '#414141',
	['button'] = '#323232',
	['button hover'] = '#282828',
	['button active'] = '#232323',
	['toggle'] = '#646464',
	['toggle hover'] = '#787878',
	['toggle cursor'] = '#2d2d2d',
	['select'] = '#2d2d2d',
	['select active'] = '#232323',
	['slider'] = '#262626',
	['slider cursor'] = '#646464',
	['slider cursor hover'] = '#787878',
	['slider cursor active'] = '#969696',
	['property'] = '#262626',
	['edit'] = '#262626',
	['edit cursor'] = '#afafaf',
	['combo'] = '#2d2d2d',
	['chart'] = '#787878',
	['chart color'] = '#2d2d2d',
	['chart color highlight'] = '#ff0000',
	['scrollbar'] = '#282828',
	['scrollbar cursor'] = '#646464',
	['scrollbar cursor hover'] = '#787878',
	['scrollbar cursor active'] = '#969696',
	['tab header'] = '#282828'
}
```

### Styles

For finer-grained control over styles, including custom image-based skinning, Nuklear provides a wide arrangement of style items.

#### nk.styleSetFont(font)
Set the current font.

See [LÖVE Font](https://love2d.org/wiki/Font).

#### nk.stylePush(style)
Push any number of [style items](#style-items) onto the style stack.

Example (see [skin.lua](https://github.com/keharriso/love-nuklear/blob/master/example/skin.lua)):
```lua
nk.stylePush {
	['text'] = {
		['color'] = '#000000'
	},
	['button'] = {
		['normal'] = love.graphics.newImage 'skin/button.png',
		['hover'] = love.graphics.newImage 'skin/button_hover.png',
		['active'] = love.graphics.newImage 'skin/button_active.png',
		['text background'] = '#00000000',
		['text normal'] = '#000000',
		['text hover'] = '#000000',
		['text active'] = '#ffffff'
	}
}
```

#### nk.stylePop()
Pop the most recently pushed style.

### Style Items
```lua
local style = {
	['font'] = Font,
	['text'] = {
		['color'] = color,
		['padding'] = {x = number, y = number}
	},
	['button'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['text background'] = color,
		['text normal'] = color,
		['text hover'] = color,
		['text active'] = color,
		['text alignment'] = align,
		['border'] = number,
		['rounding'] = number,
		['padding'] = {x = number, y = number},
		['image padding'] = {x = number, y = number},
		['touch padding'] = {x = number, y = number}
	},
	['contextual button'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['text background'] = color,
		['text normal'] = color,
		['text hover'] = color,
		['text active'] = color,
		['text alignment'] = align,
		['border'] = number,
		['rounding'] = number,
		['padding'] = {x = number, y = number},
		['image padding'] = {x = number, y = number},
		['touch padding'] = {x = number, y = number}
	},
	['menu button'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['text background'] = color,
		['text normal'] = color,
		['text hover'] = color,
		['text active'] = color,
		['text alignment'] = align,
		['border'] = number,
		['rounding'] = number,
		['padding'] = {x = number, y = number},
		['image padding'] = {x = number, y = number},
		['touch padding'] = {x = number, y = number}
	},
	['option'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['cursor normal'] = color or Image,
		['cursor hover'] = color or Image,
		['text normal'] = color,
		['text hover'] = color,
		['text active'] = color,
		['text background'] = color,
		['text alignment'] = align,
		['padding'] = {x = number, y = number},
		['touch padding'] = {x = number, y = number},
		['spacing'] = number,
		['border'] = number
	},
	['checkbox'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['cursor normal'] = color or Image,
		['cursor hover'] = color or Image,
		['text normal'] = color,
		['text hover'] = color,
		['text active'] = color,
		['text background'] = color,
		['text alignment'] = align,
		['padding'] = {x = number, y = number},
		['touch padding'] = {x = number, y = number},
		['spacing'] = number,
		['border'] = number
	},
	['selectable'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['pressed'] = color or Image,
		['normal active'] = color or Image,
		['hover active'] = color or Image,
		['pressed active'] = color or Image,
		['text normal'] = color,
		['text hover'] = color,
		['text pressed'] = color,
		['text normal active'] = color,
		['text hover active'] = color,
		['text pressed active'] = color,
		['text background'] = color,
		['text alignment'] = align,
		['rounding'] = number,
		['padding'] = {x = number, y = number},
		['touch padding'] = {x = number, y = number},
		['image padding'] = {x = number, y = number}
	},
	['slider'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['bar normal'] = color,
		['bar active'] = color,
		['bar filled'] = color,
		['cursor normal'] = color or Image,
		['cursor hover'] = color or Image,
		['cursor active'] = color or Image,
		['border'] = number,
		['rounding'] = number,
		['bar height'] = number,
		['padding'] = {x = number, y = number},
		['spacing'] = {x = number, y = number},
		['cursor size'] = {x = number, y = number}
	},
	['progress'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['cursor normal'] = color or Image,
		['cursor hover'] = color or Image,
		['cursor active'] = color or Image,
		['cursor border color'] = color,
		['rounding'] = number,
		['border'] = number,
		['cursor border'] = number,
		['cursor rounding'] = number,
		['padding'] = {x = number, y = number}
	},
	['property'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['label normal'] = color,
		['label hover'] = color,
		['label active'] = color,
		['border'] = number,
		['rounding'] = number,
		['padding'] = {x = number, y = number},
		['edit'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['scrollbar'] = {
				['normal'] = color or Image,
				['hover'] = color or Image,
				['active'] = color or Image,
				['border color'] = color,
				['cursor normal'] = color or Image,
				['cursor hover'] = color or Image,
				['cursor active'] = color or Image,
				['cursor border color'] = color,
				['border'] = number,
				['rounding'] = number,
				['border cursor'] = number,
				['rounding cursor'] = number,
				['padding'] = {x = number, y = number}
			},
			['cursor normal'] = color,
			['cursor hover'] = color,
			['cursor text normal'] = color,
			['cursor text hover'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['selected normal'] = color,
			['selected hover'] = color,
			['selected text normal'] = color,
			['selected text hover'] = color,
			['border'] = number,
			['rounding'] = number,
			['cursor size'] = number,
			['scrollbar size'] = {x = number, y = number},
			['padding'] = {x = number, y = number},
			['row padding'] = number
		},
		['inc button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		},
		['dec button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		}
	},
	['edit'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['scrollbar'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['cursor normal'] = color or Image,
			['cursor hover'] = color or Image,
			['cursor active'] = color or Image,
			['cursor border color'] = color,
			['border'] = number,
			['rounding'] = number,
			['border cursor'] = number,
			['rounding cursor'] = number,
			['padding'] = {x = number, y = number}
		},
		['cursor normal'] = color,
		['cursor hover'] = color,
		['cursor text normal'] = color,
		['cursor text hover'] = color,
		['text normal'] = color,
		['text hover'] = color,
		['text active'] = color,
		['selected normal'] = color,
		['selected hover'] = color,
		['selected text normal'] = color,
		['selected text hover'] = color,
		['border'] = number,
		['rounding'] = number,
		['cursor size'] = number,
		['scrollbar size'] = {x = number, y = number},
		['padding'] = {x = number, y = number},
		['row padding'] = number
	},
	['chart'] = {
		['background'] = color or Image,
		['border color'] = color,
		['selected color'] = color,
		['color'] = color,
		['border'] = number,
		['rounding'] = number,
		['padding'] = {x = number, y = number}
	},
	['scrollh'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['cursor normal'] = color or Image,
		['cursor hover'] = color or Image,
		['cursor active'] = color or Image,
		['cursor border color'] = color,
		['border'] = number,
		['rounding'] = number,
		['border cursor'] = number,
		['rounding cursor'] = number,
		['padding'] = {x = number, y = number}
	},
	['scrollv'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['cursor normal'] = color or Image,
		['cursor hover'] = color or Image,
		['cursor active'] = color or Image,
		['cursor border color'] = color,
		['border'] = number,
		['rounding'] = number,
		['border cursor'] = number,
		['rounding cursor'] = number,
		['padding'] = {x = number, y = number}
	},
	['tab'] = {
		['background'] = color or Image,
		['border color'] = color,
		['text'] = color,
		['tab maximize button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		},
		['tab minimize button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		},
		['node maximize button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		},
		['node minimize button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		},
		['border'] = number,
		['rounding'] = number,
		['indent'] = number,
		['padding'] = {x = number, y = number},
		['spacing'] = {x = number, y = number}
	},
	['combo'] = {
		['normal'] = color or Image,
		['hover'] = color or Image,
		['active'] = color or Image,
		['border color'] = color,
		['label normal'] = color,
		['label hover'] = color,
		['label active'] = color,
		['symbol normal'] = color,
		['symbol hover'] = color,
		['symbol active'] = color,
		['button'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['border color'] = color,
			['text background'] = color,
			['text normal'] = color,
			['text hover'] = color,
			['text active'] = color,
			['text alignment'] = align,
			['border'] = number,
			['rounding'] = number,
			['padding'] = {x = number, y = number},
			['image padding'] = {x = number, y = number},
			['touch padding'] = {x = number, y = number}
		},
		['border'] = number,
		['rounding'] = number,
		['content padding'] = {x = number, y = number},
		['button padding'] = {x = number, y = number},
		['spacing'] = {x = number, y = number}
	},
	['window'] = {
		['header'] = {
			['normal'] = color or Image,
			['hover'] = color or Image,
			['active'] = color or Image,
			['close button'] = {
				['normal'] = color or Image,
				['hover'] = color or Image,
				['active'] = color or Image,
				['border color'] = color,
				['text background'] = color,
				['text normal'] = color,
				['text hover'] = color,
				['text active'] = color,
				['text alignment'] = align,
				['border'] = number,
				['rounding'] = number,
				['padding'] = {x = number, y = number},
				['image padding'] = {x = number, y = number},
				['touch padding'] = {x = number, y = number}
			},
			['minimize button'] = {
				['normal'] = color or Image,
				['hover'] = color or Image,
				['active'] = color or Image,
				['border color'] = color,
				['text background'] = color,
				['text normal'] = color,
				['text hover'] = color,
				['text active'] = color,
				['text alignment'] = align,
				['border'] = number,
				['rounding'] = number,
				['padding'] = {x = number, y = number},
				['image padding'] = {x = number, y = number},
				['touch padding'] = {x = number, y = number}
			},
			['label normal'] = color,
			['label hover'] = color,
			['label active'] = color,
			['padding'] = {x = number, y = number},
			['label padding'] = {x = number, y = number},
			['spacing'] = {x = number, y = number},
			
		},
		['fixed background'] = color or Image,
		['background'] = color,
		['border color'] = color,
		['popup border color'] = color,
		['combo border color'] = color,
		['contextual border color'] = color,
		['menu border color'] = color,
		['group border color'] = color,
		['tooltip border color'] = color,
		['scaler'] = color or Image,
		['border'] = number,
		['combo border'] = number,
		['contextual border'] = number,
		['menu border'] = number,
		['group border'] = number,
		['tooltip border'] = number,
		['popup border'] = number,
		['rounding'] = number,
		['spacing'] = {x = number, y = number},
		['scrollbar size'] = {x = number, y = number},
		['min size'] = {x = number, y = number},
		['padding'] = {x = number, y = number},
		['group padding'] = {x = number, y = number},
		['popup padding'] = {x = number, y = number},
		['combo padding'] = {x = number, y = number},
		['contextual padding'] = {x = number, y = number},
		['menu padding'] = {x = number, y = number},
		['tooltip padding'] = {x = number, y = number}
	}
}
```
