---@module nuklear

---Initialize the library. This must be called before any of the other functions.
function init() end
---Close the library, freeing all associated resources. A subsequent call to `nk.init` is required before using any other functions.
function shutdown() end

---Pass the given key press event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.keypressed](https://love2d.org/wiki/love.keypressed).
---@return boolean @consumed
function keypressed(key, scancode, isrepeat) end

---Pass the given key release event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.keyreleased](https://love2d.org/wiki/love.keyreleased).
---@return boolean @consumed
function keyreleased(key, scancode) end

---Pass the given mouse press event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.mousepressed](https://love2d.org/wiki/love.mousepressed).
---@return boolean @consumed
function mousepressed(x, y, button, istouch) end

---Pass the given mouse release event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.mousereleased](https://love2d.org/wiki/love.mousereleased).
---@return boolean @consumed
function mousereleased(x, y, button, istouch) end

---Pass the given mouse move event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.mousemoved](https://love2d.org/wiki/love.mousemoved).
---@return boolean @consumed
function mousemoved(x, y, dx, dy, istouch) end

---Pass the given text input event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.textinput](https://love2d.org/wiki/love.textinput).
---@return boolean @consumed
function textinput(text) end

---Pass the given wheel move event to the UI, returning `true` if the event is consumed and `false` otherwise.
---See [love.wheelmoved](https://love2d.org/wiki/love.wheelmoved).
---@return boolean @consumed
function wheelmoved(x, y) end

---Draw the UI. Call this once every [love.draw](https://love2d.org/wiki/love.draw).
function draw() end

---Begin a new frame for the UI. Call this once every [love.update](https://love2d.org/wiki/love.update), before other UI calls.
function frameBegin() end

---End the current frame. Call this once every [love.update](https://love2d.org/wiki/love.update), after other UI calls.
function frameEnd() end

---Create or update a window with the given `name`. The `name` is a unique identifier used internally to differentiate between windows. If unspecified, the `name` defaults to the `title`. The `x`, `y`, `width`, and `height` parameters describe the window's initial bounds. All additional arguments are interpreted as window [flags](#flags).
---@return boolean `true` if the window is open and `false` if it is closed or collapsed.
---@param flags NK_Window_Flags
---@param x number
---@param y number
---@param width number
---@param height number
---@param title string
function windowBegin(title, x, y, width, height, flags, ...) end

---Create or update a window with the given `name`. The `name` is a unique identifier used internally to differentiate between windows. If unspecified, the `name` defaults to the `title`. The `x`, `y`, `width`, and `height` parameters describe the window's initial bounds. All additional arguments are interpreted as window [flags](#flags).
---@return boolean `true` if the window is open and `false` if it is closed or collapsed.
---@param flags NK_Window_Flags
---@param x number
---@param y number
---@param width number
---@param height number
---@param title string
---@param name string
function windowBegin(name, title, x, y, width, height, flags, ...) end

---End a window. This must always be called after `nk.windowBegin`, regardless of whether or not the window is open.
function windowEnd() end

---Return the bounds of the current window.
---@return x, y, width, height
function windowGetBounds() end

---Return the position of the current window.
---@return x, y
function windowGetPosition() end

---Return the size of the current window.
---@return width, height
function windowGetSize() end

---Return the bounds of the current window's content region.
---@return x, y, width, height
function windowGetContentRegion() end

---Return `true` if the current window is focused, and `false` otherwise.
---@return boolean
function windowHasFocus() end

---Return 'true' if the given window is collapsed, and `false` otherwise.
---@return boolean
function windowIsCollapsed(name) end

---Return `true` if the given window is active, and `false` otherwise.
---@return boolean
function windowIsActive(name) end

---Return `true` if the current window is hovered by the mouse, and `false` otherwise.
---@return boolean
function windowIsHovered() end

---Return `true` if any window is hovered by the mouse, and `false` otherwise.
---@return boolean
function windowIsAnyHovered() end

---Set the bounds of the current window.
---@param x number
---@param y number
---@param width number
---@param height number
function windowSetBounds(x, y, width, height) end

---Set the position of the current window.
---@param x number
---@param y number
function windowSetPosition(x, y) end

---Set the size of the current window.
---@param width number
---@param height number
function windowSetSize(width, height) end

---Focus on the given window.
function windowSetFocus(name) end

---Close the given window.
function windowClose(name) end

---Collapse the given window.
function windowCollapse(name) end

---Expand the given window.
function windowExpand(name) end

---Show the given window.
function windowShow(name) end

---Hide the given window.
function windowHide(name) end

---Hide the given window.
function windowHide(name) end

---Adopt a row layout for the proceeding widgets.
---@param mode NK_Layout_Mode_Dynamic @dynamic layout
---@param height number @height in pixel
---@param cols number @column count
function layoutRow(mode, height, cols) end

---Adopt a row layout for the proceeding widgets.
---@param mode NK_Layout_Mode_Dynamic @dynamic layout
---@param height number @height in pixel
---@param ratios number[] @column with ratios
function layoutRow(mode, height, ratios) end

---Adopt a row layout for the proceeding widgets.
---@param mode NK_Layout_Mode_Static @static layout
---@param height number @height in pixel
---@param itemWidth number @column with size(pixel)
---@param cols number @column count
function layoutRow(mode, height, itemWidth, cols) end

---Adopt a row layout for the proceeding widgets.
---@param mode NK_Layout_Mode_Static @static layout
---@param height number @height in pixel
---@param sizes number[] @column with size(pixel)
function layoutRow(mode, height, sizes) end

---Adopt a row layout of the specified format type, height, and column count. Before each proceeding widget, call `nk.layoutRowPush` to set the column size. Don't forget to end the layout with `nk.layoutRowEnd`.
---@param mode NK_Layout_Mode
---@param height number @height in pixel
---@param cols number @column count
function layoutRowBegin(mode, height, cols) end

---Specify the width of the next widget in a row layout started with `nk.layoutRowBegin`.
---@param width If the layout is dynamic, the width is specified as a ratio of the total row width from 0 to 1. If the layout is static, the width is specified as a number of pixels.
function layoutRowPush(width) end

---Call after `nk.layoutRowBegin` in order to properly end the row layout.
function layoutRowEnd() end

---Start a space layout with the given height and widget count. Call `nk.layoutSpacePush` before each proceeding widget and `nk.layoutSpaceEnd` after the layout is finished.
---@param mode NK_Layout_Mode
---@param height number
---@param widgetCount number
function layoutSpaceBegin(mode, height, widgetCount) end

---Start a space layout with the given height and widget count. Call `nk.layoutSpacePush` before each proceeding widget and `nk.layoutSpaceEnd` after the layout is finished.
---@param x number
---@param y number
---@param width number
---@param height number
function layoutSpacePush(x, y, width, height) end

---End a space layout.
function layoutSpaceEnd() end

---Return the bounds of the current space layout.
---@return x, y, width, height
function layoutSpaceBounds() end

---Convert a space layout local position to global screen position.
---@return x, y
function layoutSpaceToScreen(x, y) end

---Convert a global screen position to space layout local position.
---@return x, y
function layoutSpaceToLocal(x, y) end

---Convert space layout local bounds to global screen bounds.
---@return x, y, width, height
function layoutSpaceRectToScreen(x, y, width, height) end

---Convert global screen bounds to space layout local.
---@return x, y, width, height
function layoutSpaceRectToLocal(x, y, width, height) end

---Convert a pixel width to a ratio suitable for a dynamic layout.
---@return ratio
function layoutRatioFromPixel(pixelWidth) end

---Start a group. Groups can have titles and scrollbars just like windows.
---Call `nk.groupEnd` at the end of a group if it's open.
---@return boolean @Return `true` if the group is open and `false` otherwise.
---@param flags NK_Window_Flags
function groupBegin(title, flags, ...) end

---End a group. Remember to call this whenever the group is open.
function groupEnd() end

---Start a tree. The resulting item is either a `'node'` or a `'tab'`, with the idea being that nodes are a level below tabs. Optionally specify an image (default is none) or a starting state (default is `'collapsed'`).
---Remember to call `nk.treePop` if the item is open.
---@return boolean @Return `true` if the item is expanded, and `false` if it is collapsed.
---@param type NK_Tree_Type
---@param title string
---@param image string
---@param collapsed_type NK_Collapsed_Type
function treePush(type, title, image, collapsed_type) end

---Start a tree. The resulting item is either a `'node'` or a `'tab'`, with the idea being that nodes are a level below tabs. Optionally specify an image (default is none) or a starting state (default is `'collapsed'`).
---Remember to call `nk.treePop` if the item is open.
---@return boolean @Return `true` if the item is expanded, and `false` if it is collapsed.
---@param type NK_Tree_Type
---@param title string
---@param image string
function treePush(type, title, image) end

---Start a tree. The resulting item is either a `'node'` or a `'tab'`, with the idea being that nodes are a level below tabs. Optionally specify an image (default is none) or a starting state (default is `'collapsed'`).
---Remember to call `nk.treePop` if the item is open.
---@return boolean @Return `true` if the item is expanded, and `false` if it is collapsed.
---@param type NK_Tree_Type
---@param title string
function treePush(type, title) end

---Ends a tree. Call this at the end of an open tree item.
function treePop() end

---Start a popup with the given size and [flags](#flags). Bounds can be given as either dynamic ratios or static pixel counts.
---Call `nk.popupEnd` to end the popup if it is open.
---@return boolean @`true` if the popup is open, and `false` otherwise.
function popupBegin(mode, title, x, y, width, height, flags, ...) end

---Close the current popup.
function popupClose() end

---End a popup. Be sure to call this when ending an open popup.
function popupEnd() end

---Set up a context menu of the given size and trigger bounds. Also takes window [flags](#flags).
---@return boolean @Return `true` if the context menu is open, and `false` otherwise.
function contextualBegin(width, height, triggerX, triggerY, triggerWidth, triggerHeight, flags, ...) end

---Add an item to a context menu. Optionally specify a [symbol](#symbols) type, image, and/or [alignment](#alignment).
---Call `nk.contextualEnd` at the end of an open context menu.
---@return boolean @Return `true` if the item is activated, and `false` otherwise.
---@param text string
---@param icon NK_Symbols|Image
---@param alignment NK_Alignment
function contextualItem(text, icon, alignment) end

---Close the current context menu.
function contextualClose() end

---End the current context menu. Be sure to call this at the end of an open context menu..
function contextualEnd() end

---Show a tooltip with the given text.
function tooltip(text) end

---Start a tooltip with the given width.
---Be sure to call `nk.tooltipEnd` at the end of an open tooltip.
---@return boolean @Return `true` if the tooltip is open, and `false` otherwise.
function tooltipBegin(width) end

---End a tooltip previously started with `nk.tooltipBegin`. Call this at the end of every open tooltip.
function tooltipEnd() end

---Start a menu bar. Menu bars stay at the top of a window even when scrolling. Call `nk.menubarEnd` to end one.
function menubarBegin() end

---Ends a menu bar. Always call this at the end of a menu bar started with `nk.menubarBegin`.
function menubarEnd() end

---Start a menu of the given title and size. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).
---Be sure to call `nk.menuEnd` when ending open menus.
---@param title string
---@param icon NK_Symbols|Image
---@param width number
---@param height number
---@param alignment NK_Alignment
---@return boolean @Return `true` if the menu is open, and `false` otherwise.
function menuBegin(title, icon, width, height, alignment) end

---Start a menu of the given title and size. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).
---Be sure to call `nk.menuEnd` when ending open menus.
---@param title string
---@param icon NK_Symbols|Image
---@param width number
---@param height number
---@return boolean @Return `true` if the menu is open, and `false` otherwise.
function menuBegin(title, icon, width, height) end

---Add a menu item to the current menu. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).
---@param title string
---@param icon NK_Symbols|Image
---@param alignment NK_Alignment
---@return boolean @Return `true` if the menu item is activated, and `false` otherwise.
function menuItem(title, icon, alignment) end

---Add a menu item to the current menu. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).
---@param title string
---@param icon NK_Symbols|Image
---@return boolean @Return `true` if the menu item is activated, and `false` otherwise.
function menuItem(title, icon) end

---Add a menu item to the current menu. Optionally specify a [symbol](#symbols), image, and/or [alignment](#alignment).
---@param title string
---@return boolean @Return `true` if the menu item is activated, and `false` otherwise.
function menuItem(title) end

---Close the current menu.
function menuClose() end

---End the current menu. Always call this at the end of any open menu.
function menuEnd() end

---Show a text string. Optionally specify an [alignment](#alignment) and/or [color](#colors).
---@param text string
---@param alignment NK_Alignment_Wrap|NK_Alignment
---@param color string
function label(text, alignment, color) end

---Show a text string. Optionally specify an [alignment](#alignment) and/or [color](#colors).
---@param text string
---@param alignment NK_Alignment_Wrap|NK_Alignment
function label(text, alignment) end

---Show a text string. Optionally specify an [alignment](#alignment) and/or [color](#colors).
---@param text string
function label(text) end

---Show an image.
---See [LÖVE Image](https://love2d.org/wiki/Image).
---@param img Image
function image(img) end

---Add a button with a title and/or a [color](#colors), [symbol](#symbols), or image.
---@param title string
---@param bg string|NK_Symbols|Image
---@return boolean @Return `true` if activated, and `false` otherwise.
function button(title, bg) end

---Add a button with a title
---@param title string
---@return boolean @Return `true` if activated, and `false` otherwise.
function button(title) end

---Sets whether a button is activated once per click (`'default'`) or every frame held down (`'repeater'`).
---@param behavior NK_ButtonBehavior
function buttonSetBehavior(behavior) end

---Push button behavior.
---@param behavior NK_ButtonBehavior
function buttonPushBehavior(behavior) end

---Pop button behavior.
function buttonPopBehavior() end

---Add a checkbox with the given title. Either specify a boolean state `active`, in which case the function returns the new state, or specify a table with a boolean field called `value`, in which case the value is updated and the function returns `true` on toggled, and `false` otherwise.
---@param text string
---@param active boolean
---@return boolean @active
function checkbox(text, active) end

---@class NK_ValueHolder
---@field public value boolean|string

---Add a checkbox with the given title. Either specify a boolean state `active`, in which case the function returns the new state, or specify a table with a boolean field called `value`, in which case the value is updated and the function returns `true` on toggled, and `false` otherwise.
---@param text string
---@param valueTable NK_ValueHolder
---@return boolean @changed
function checkbox(text, valueTable) end

---Add a radio button with the given name and/or title. The title is displayed to the user while the name is used to report which button is selected. By default, the name is the same as the title.
---If called with a string `selection`, the function returns the new `selection`, which should be the `name` of a radio button. If called with a table that has a string field `value`, the `value` gets updated and the function returns `true` on selection change and `false` otherwise.
---@param text string
---@param selection string
---@return string @selection
---@overload
function radio(text, selection) end

---Add a radio button with the given name and/or title. The title is displayed to the user while the name is used to report which button is selected. By default, the name is the same as the title.
---If called with a string `selection`, the function returns the new `selection`, which should be the `name` of a radio button. If called with a table that has a string field `value`, the `value` gets updated and the function returns `true` on selection change and `false` otherwise.
---@param name string
---@param text string
---@param selection string
---@return string @selection
---@overload
function radio(name, text, selection) end

---Add a radio button with the given name and/or title. The title is displayed to the user while the name is used to report which button is selected. By default, the name is the same as the title.
---If called with a string `selection`, the function returns the new `selection`, which should be the `name` of a radio button. If called with a table that has a string field `value`, the `value` gets updated and the function returns `true` on selection change and `false` otherwise.
---@param text string
---@param valueTable NK_ValueHolder
---@return boolean @changed
---@overload
function radio(text, valueTable) end

---Add a radio button with the given name and/or title. The title is displayed to the user while the name is used to report which button is selected. By default, the name is the same as the title.
---If called with a string `selection`, the function returns the new `selection`, which should be the `name` of a radio button. If called with a table that has a string field `value`, the `value` gets updated and the function returns `true` on selection change and `false` otherwise.
---@param name string
---@param text string
---@param valueTable NK_ValueHolder
---@return boolean @changed
---@overload
function radio(name, text, valueTable) end

---Add a selectable item with the given text and/or image and [alignment](#alignment).
---If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param text string
---@param image Image
---@param alignment NK_Alignment
---@param selected boolean
---@return boolean @selected
---@overload
function selectable(text, image, alignment, selected) end

---Add a selectable item with the given text and/or image and [alignment](#alignment).
---If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param text string
---@param image Image
---@param selected boolean
---@return boolean @selected
---@overload
function selectable(text, image, selected) end

---Add a selectable item with the given text and/or image and [alignment](#alignment).
---If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param text string
---@param selected boolean
---@return boolean @selected
---@overload
function selectable(text, selected) end

---Add a selectable item with the given text and/or image and [alignment](#alignment).
---If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param text string
---@param image Image
---@param alignment NK_Alignment
---@param valueTable NK_ValueHolder
---@return boolean @changed
---@overload
function selectable(text, image, alignment, valueTable) end

---Add a selectable item with the given text and/or image and [alignment](#alignment).
---If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param text string
---@param image Image
---@param valueTable NK_ValueHolder
---@return boolean @changed
---@overload
function selectable(text, image, valueTable) end

---Add a selectable item with the given text and/or image and [alignment](#alignment).
---If given a boolean `selected`, return the new state of `selected`. If given a table with a boolean field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param text string
---@param valueTable NK_ValueHolder
---@return boolean @changed
---@overload
function selectable(text, valueTable) end

---Add a slider widget with the given range and step size.
---If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param min number
---@param current number
---@param max number
---@param step number
---@return number @current
function slider(min, current, max, step) end

---Add a slider widget with the given range and step size.
---If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param min number
---@param valueTable NK_ValueHolder
---@param max number
---@param step number
---@return boolean @changed
function slider(min, valueTable, max, step) end

---Add a progress widget, optionally making it modifiable.
---If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param current number
---@param max number
---@param modifiable boolean
---@return number @current
function progress(current, max, modifiable) end

---Add a progress widget, optionally making it modifiable.
---If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param current number
---@param max number
---@return number @current
function progress(current, max) end

---Add a progress widget, optionally making it modifiable.
---If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param max number
---@param modifiable boolean
---@return boolean @changed
function progress(valueTable, max, modifiable) end

---Add a progress widget, optionally making it modifiable.
---If given a number `current`, return the new `current` value. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on a change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param max number
---@return boolean @changed
function progress(valueTable, max) end

---Add a color picker widget, optionally specifying format (default 'RGB', no alpha).
---If given a `[color](#colors)` string, return the new `[color](#colors)`. If given a table with a [color](#colors) string field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.
---@param color string
---@return string @color
function colorPicker(color) end

---Add a color picker widget, optionally specifying format (default 'RGB', no alpha).
---If given a `[color](#colors)` string, return the new `[color](#colors)`. If given a table with a [color](#colors) string field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.
---@param color string
---@param mode NK_ColorMode
---@return string @color
function colorPicker(color, mode) end

---Add a color picker widget, optionally specifying format (default 'RGB', no alpha).
---If given a `[color](#colors)` string, return the new `[color](#colors)`. If given a table with a [color](#colors) string field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@return boolean @changed
function colorPicker(valueTable) end

---Add a color picker widget, optionally specifying format (default 'RGB', no alpha).
---If given a `[color](#colors)` string, return the new `[color](#colors)`. If given a table with a [color](#colors) string field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param mode NK_ColorMode
---@return boolean @changed
function colorPicker(valueTable, mode) end

---Add a property widget, which is a named number variable. Specify the range, step, and sensitivity.
---If given a number `current`, return the new `current`. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.
---@param name string
---@param min number
---@param current number
---@param max number
---@param step number
---@param incPerPixel number
---@return number @current
function property(name, min, current, max, step, incPerPixel) end

---Add a property widget, which is a named number variable. Specify the range, step, and sensitivity.
---If given a number `current`, return the new `current`. If given a table with a number field named `value` instead, the field gets updated and the function returns `true` on change and `false` otherwise.
---@param name string
---@param min number
---@param valueTable NK_ValueHolder
---@param max number
---@param step number
---@param incPerPixel number
---@return boolean @changed
function property(name, min, valueTable, max, step, incPerPixel) end

---Add an editable text field widget. The first argument defines the type of editor to use: single line 'simple' and 'field', or multi-line 'box'. The `valueTable` should be a table with a string field named `value`. The field gets updated and the function returns the edit state (one of 'commited'/'activated'/'deactivated'/'active'/'inactive') followed by `true` if the text changed or `false` if the text remained the same.
---@param type NK_EditType
---@param valueTable NK_ValueHolder
---@return state, changed
function edit(type, valueTable) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param index number
---@param items string[]
---@param itemHeight number
---@param width number
---@param height number
---@return number @index
function combobox(index, items, itemHeight, width, height) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param index number
---@param items string[]
---@param itemHeight number
---@param width number
---@return number @index
function combobox(index, items, itemHeight, width) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param index number
---@param items string[]
---@param itemHeight number
---@return number @index
function combobox(index, items, itemHeight) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param index number
---@param items string[]
---@return number @index
function combobox(index, items) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param items string[]
---@param itemHeight number
---@param width number
---@param height number
---@return boolean @changed
function combobox(valueTable, items, itemHeight, width, height) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param items string[]
---@return boolean @changed
function combobox(valueTable, items) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param items string[]
---@param itemHeight number
---@return boolean @changed
function combobox(valueTable, items, itemHeight) end

---Add a drop-down combobox widget. `items` should be an array of strings. `itemHeight` defaults to the widget height, `width` defaults to widget width, and `height` defaults to a sensible value based on `itemHeight`.
---If a number `index` is specified, then the function returns the new selected `index`. If a table with a number field `value` is given instead, then the field gets updated with the currently selected index and the function returns `true` on change and `false` otherwise.
---@param valueTable NK_ValueHolder
---@param items string[]
---@param itemHeight number
---@param width number
---@return boolean @changed
function combobox(valueTable, items, itemHeight, width) end

---Start a combobox widget. This form gives complete control over the drop-down list (it's treated like a new window). [Color](#colors)/[symbol](#symbols)/image defaults to none, while width and height default to sensible values based on widget bounds.
---Remember to call `nk.comboboxEnd` if the combobox is open.
---@param text string
---@param icon string|NK_Symbols|Image
---@param width number
---@return boolean @open
function comboboxBegin(text, icon, width) end

---Start a combobox widget. This form gives complete control over the drop-down list (it's treated like a new window). [Color](#colors)/[symbol](#symbols)/image defaults to none, while width and height default to sensible values based on widget bounds.
---Remember to call `nk.comboboxEnd` if the combobox is open.
---@param text string
---@param icon string|NK_Symbols|Image
---@return boolean @open
function comboboxBegin(text, icon) end

---Start a combobox widget. This form gives complete control over the drop-down list (it's treated like a new window). [Color](#colors)/[symbol](#symbols)/image defaults to none, while width and height default to sensible values based on widget bounds.
---Remember to call `nk.comboboxEnd` if the combobox is open.
---@param text string
---@return boolean @open
function comboboxBegin(text) end

---Start a combobox widget. This form gives complete control over the drop-down list (it's treated like a new window). [Color](#colors)/[symbol](#symbols)/image defaults to none, while width and height default to sensible values based on widget bounds.
---Remember to call `nk.comboboxEnd` if the combobox is open.
---@param text string
---@param icon string|NK_Symbols|Image
---@param width number
---@param height number
---@return boolean @open
function comboboxBegin(text, icon, width, height) end

---Add a combobox item, optionally specifying a [symbol](#symbols), image, and/or [alignment](#alignment).
---@param text string
---@param icon NK_Symbols|Image
---@param alignment NK_Alignment
---@return boolean @Return `true` if the item is activated, and `false` otherwise.
function comboboxItem(text, icon, alignment) end

---Add a combobox item, optionally specifying a [symbol](#symbols), image, and/or [alignment](#alignment).
---@param text string
---@param icon NK_Symbols|Image
---@return boolean @Return `true` if the item is activated, and `false` otherwise.
function comboboxItem(text, icon) end

---Add a combobox item, optionally specifying a [symbol](#symbols), image, and/or [alignment](#alignment).
---@param text string
---@return boolean @Return `true` if the item is activated, and `false` otherwise.
function comboboxItem(text) end

---Close the current combobox.
function comboboxClose() end

---End the current combobox. Always call this at the end of open comboboxes..
function comboboxEnd() end

---Return the bounds of the current widget.
---@return number,number,number,number @x, y, width, height
function widgetBounds() end

---Return the position of the current widget.
---@return number,number @x, y
function widgetPosition() end

---Return the size of the current widget.
---@return number,number @width, height
function widgetSize() end

---Return the width of the current widget.
---@return number @width
function widgetWidth() end

---Return the height of the current widget.
---@return number @height
function widgetHeight() end

---Return `true` if the widget is hovered by the mouse, and `false` otherwise.
---@return boolean @hovered
function widgetIsHovered() end

---Return `true` if the given mouse button was pressed on the current widget and has not yet been released, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@return boolean @pressed
function widgetHasMousePressed() end

---Return `true` if the given mouse button was pressed on the current widget and has not yet been released, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @pressed
function widgetHasMousePressed(button) end

---Return `true` if the given mouse button was released on the current widget and has not since been pressed, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@return boolean @released
function widgetHasMouseReleased() end

---Return `true` if the given mouse button was released on the current widget and has not since been pressed, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @released
function widgetHasMouseReleased(button) end

---Return `true` if the given mouse button was pressed on the current widget this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@return boolean @pressed
function widgetIsMousePressed() end

---Return `true` if the given mouse button was pressed on the current widget this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @pressed
function widgetIsMousePressed(button) end

---Return `true` if the given mouse button was released on the current widget this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@return boolean released
function widgetIsMouseReleased() end

---Return `true` if the given mouse button was released on the current widget this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean released
function widgetIsMouseReleased(button) end

---Empty space taking up the given number of columns.
---@param cols number
function spacing(cols) end

---Draw a multi-segment line at the given screen coordinates.
function line(x1, y1, x2, y2, ...) end

---Draw a Bézier curve with the given start, control, and end points.
function curve(x1, y1, crtl1x, ctrl1y, ctrl2x, ctrl2y, x2, y2) end

---Draw a polygon with the given draw mode and screen coordinates.
---@param mode DrawMode
function polygon(mode, x1, y1, x2, y2, x3, y3, ...) end

---Draw a circle with the given draw mode, center screen coordinates, and radius.
---@param mode DrawMode
function circle(mode, x, y, r) end

---Draw an ellipse with the given draw mode, center screen coordinates, and radii.
---@param mode DrawMode
function ellipse(mode, x, y, rx, ry) end

---Draw an arc with the given draw mode, screen coordinates, radius, and angles.
---@param mode DrawMode
function arc(mode, x, y, r, startAngle, endAngle) end

---Draw a gradient rectangle with the given screen coordinates, size, and corner colors.
function rectMultiColor(x, y, width, height, topLeftColor, topRightColor, bottomLeftColor, bottomRightColor) end

---Set the scissor area to the given screen coordinates and size.
function scissor(x, y, width, height) end

---Draw the given image at the given screen bounds.
---See [LÖVE Image](https://love2d.org/wiki/Image).
---@param img Image
function image(img, x, y, width, height) end

---Draw the given string at the given screen bounds.
function text(str, x, y, width, height) end

---Return `true` if the given screen bounds were hovered by the mouse in the previous frame, and `false` otherwise.
---@return boolean @hovered
function inputWasHovered(x, y, width, height) end

---Return `true` if the given screen bounds are hovered by the mouse, and `false` otherwise.
---@return boolean @hovered
function inputIsHovered(x, y, width, height) end

---Return `true` if the given mouse button was pressed in the given screen bounds and has not yet been released, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @pressed
function inputHasMousePressed(button, x, y, width, height) end

---Return `true` if the given mouse button was released in the given screen bounds and has not since been pressed, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @released
function inputHasMouseReleased(button, x, y, width, height) end

---Return `true` if the given mouse button was pressed in the given screen bounds this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @pressed
function inputIsMousePressed(button, x, y, width, height) end

---Return `true` if the given mouse button was released in the given screen bounds this frame, and `false` otherwise. `button` is one of 'left'/'right'/'middle' (defaults to 'left').
---@param button NK_MouseButtonType
---@return boolean @released
function inputIsMouseReleased(button, x, y, width, height) end

---Construct a color string from the given components (each from 0 to 255). Alpha (`a`) defaults to 255.
---@return string
function colorRGBA(r, g, b) end

---Construct a color string from the given components (each from 0 to 255). Alpha (`a`) defaults to 255.
---@return string
function colorRGBA(r, g, b, a) end

---Construct a color string from the given components (each from 0 to 255). Alpha (`a`) defaults to 255.
---@return string
function colorHSVA(r, g, b) end

---Construct a color string from the given components (each from 0 to 255). Alpha (`a`) defaults to 255.
---@return string
function colorHSVA(r, g, b, a) end

---Split a color string into its number components.
---@return number,number.number,number @r, g, b, a
function colorParseRGBA(color) end

---Split a color string into its number components.
---@return number,number.number,number @h, s, v, a
function colorParseRGBA(color) end

---Reset color styles to their default values.
function styleDefault() end

---Load a color table for quick color styling.
---@param colorTable ColorTable
function styleLoadColors(colorTable) end

---Set the current font.
---See [LÖVE Font](https://love2d.org/wiki/Font).
---@param font Font
function styleSetFont(font) end

---Push any number of [style items](#style-items) onto the style stack.
---
---Example (see [skin.lua](https://github.com/keharriso/love-nuklear/blob/master/example/skin.lua)):
---```lua
---nk.stylePush {
---    ['text'] = {
---        ['color'] = '#000000'
---    },
---    ['button'] = {
---        ['normal'] = love.graphics.newImage 'skin/button.png',
---        ['hover'] = love.graphics.newImage 'skin/button_hover.png',
---        ['active'] = love.graphics.newImage 'skin/button_active.png',
---        ['text background'] = '#00000000',
---        ['text normal'] = '#000000',
---        ['text hover'] = '#000000',
---        ['text active'] = '#ffffff'
---    }
---}
---```
---@param style NK_Style
function stylePush(style) end

---Pop the most recently pushed style.
function stylePop() end

---@class NK_Pos
---@field x number
---@field y number

---@class NK_Color : string

---@class NK_TextStyle
---@field color string
---@field padding NK_Pos

---@class NK_ButtonStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field text_background NK_Color
---@field text_normal NK_Color
---@field text_hover NK_Color
---@field text_active NK_Color
---@field text_alignment NK_Alignment
---@field border number
---@field rounding number
---@field padding NK_Pos
---@field image_padding NK_Pos
---@field touch_padding NK_Pos

---@class NK_OptionStyle:NK_ButtonStyle
---@field spacing number
---@field border number

---@class NK_SelectableStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field pressed NK_Color|Image
---@field normal_active NK_Color|Image
---@field hover_active NK_Color|Image
---@field pressed_active NK_Color|Image
---@field text_normal NK_Color
---@field text_hover NK_Color
---@field text_pressed NK_Color
---@field text_normal_active NK_Color
---@field text_hover_active NK_Color
---@field text_pressed_active NK_Color
---@field text_background NK_Color
---@field text_alignment NK_Alignment
---@field rounding number
---@field padding NK_Pos
---@field touch_padding NK_Pos
---@field image_padding NK_Pos

---@class NK_SliderStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field bar_normal NK_Color
---@field bar_active NK_Color
---@field bar_filled NK_Color
---@field cursor_normal NK_Color|Image
---@field cursor_hover NK_Color|Image
---@field cursor_active NK_Color|Image
---@field border number
---@field rounding number
---@field bar_height number
---@field padding NK_Pos
---@field spacing NK_Pos
---@field cursor_size NK_Pos

---@class NK_ProgressStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field cursor_normal NK_Color|Image
---@field cursor_hover NK_Color|Image
---@field cursor_active NK_Color|Image
---@field cursor_border_color NK_Color
---@field rounding number
---@field border number
---@field cursor_border number
---@field cursor_rounding number
---@field padding NK_Pos

---@class NK_EditStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field scrollbar NK_ProgressStyle
---@field cursor_normal NK_Color
---@field cursor_hover NK_Color
---@field cursor_text_normal NK_Color
---@field cursor_text_hover NK_Color
---@field text_normal NK_Color
---@field text_hover NK_Color
---@field text_active NK_Color
---@field selected_normal NK_Color
---@field selected_hover NK_Color
---@field selected_text_normal NK_Color
---@field selected_text_hover NK_Color
---@field border number
---@field rounding number
---@field cursor_size number
---@field scrollbar_size NK_Pos
---@field padding NK_Pos
---@field row_padding NK_Pos

---@class NK_PropertyStyle
---@field normal  NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field label_normal NK_Color
---@field label_hover NK_Color
---@field label_active NK_Color
---@field border number
---@field rounding number
---@field padding NK_Pos
---@field edit NK_EditStyle
---@field inc_button NK_ButtonStyle
---@field dec_button NK_ButtonStyle

---@class NK_ChartStyle
---@field background  NK_Color|Image
---@field border_color  NK_Color
---@field selected_color NK_Color
---@field color NK_Color
---@field border number
---@field rounding number
---@field padding NK_Pos

---@class NK_ScrollStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field cursor_normal NK_Color|Image
---@field cursor_hover NK_Color|Image
---@field cursor_active NK_Color|Image
---@field cursor_border_color NK_Color
---@field border number
---@field rounding number
---@field border_cursor number
---@field rounding_cursor number
---@field padding NK_Pos

---@class NK_TabStyle
---@field background NK_Color|Image
---@field border_color NK_Color
---@field text NK_Color
---@field tab_maximize_button NK_ButtonStyle
---@field tab_minimize_button NK_ButtonStyle
---@field node_maximize_button NK_ButtonStyle
---@field node_minimize_button NK_ButtonStyle
---@field border number
---@field rounding number
---@field indent number
---@field padding NK_Pos
---@field spacing NK_Pos

---@class NK_ComboStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field border_color NK_Color
---@field label_normal NK_Color
---@field label_hover NK_Color
---@field label_active NK_Color
---@field symbol_normal NK_Color
---@field symbol_hover NK_Color
---@field symbol_active NK_Color
---@field button NK_ButtonStyle
---@field border number
---@field rounding number
---@field content_padding NK_Pos
---@field button_padding NK_Pos
---@field spacing NK_Pos

---@class NK_WindowHeaderStyle
---@field normal NK_Color|Image
---@field hover NK_Color|Image
---@field active NK_Color|Image
---@field close_button NK_ButtonStyle
---@field minimize_button NK_ButtonStyle
---@field label_normal NK_Color
---@field label_hover NK_Color
---@field label_active NK_Color
---@field padding NK_Pos
---@field label_padding NK_Pos
---@field spacing NK_Pos

---@class NK_WindowStyle
---@field header NK_WindowHeaderStyle
---@field fixed_background NK_Color|Image
---@field background NK_Color
---@field border_color NK_Color
---@field popup_border_color NK_Color
---@field combo_border_color NK_Color
---@field contextual_border_color NK_Color
---@field menu_border_color NK_Color
---@field group_border_color NK_Color
---@field tooltip_border_color NK_Color
---@field scaler NK_Color|Image
---@field border number
---@field combo_border number
---@field contextual_border number
---@field menu_border number
---@field group_border number
---@field tooltip_border number
---@field popup_border number
---@field rounding number
---@field spacing NK_Pos
---@field scrollbar_size NK_Pos
---@field min_size NK_Pos
---@field padding NK_Pos
---@field group_padding NK_Pos
---@field popup_padding NK_Pos
---@field combo_padding NK_Pos
---@field contextual_padding NK_Pos
---@field menu_padding NK_Pos
---@field tooltip_padding NK_Pos

---@class NK_Style
---@field font Font
---@field text NK_TextStyle
---@field button NK_ButtonStyle
---@field contextual_button NK_ButtonStyle
---@field menu_button NK_ButtonStyle
---@field option NK_OptionStyle
---@field checkbox NK_OptionStyle
---@field selectable NK_SelectableStyle
---@field slider NK_SliderStyle
---@field progress NK_ProgressStyle
---@field property NK_PropertyStyle
---@field edit NK_EditStyle
---@field chart NK_ChartStyle
---@field scrollh NK_ScrollStyle
---@field scrollv NK_ScrollStyle
---@field tab NK_TabStyle
---@field combo NK_ComboStyle
---@field window NK_WindowStyle

