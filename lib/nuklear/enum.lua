---Windows and some window-like widgets can accept a number of window flags. Here is a list of the possible flags alongside their meanings:
---@class NK_Window_Flags

NK_Window_Flags = {
    ---Draw a border around the window.
    ---@type NK_Window_Flags
    border = 'border',
    ---The window can be moved by dragging the header.
    ---@type NK_Window_Flags
    movable = 'movable',
    ---The window can be scaled by dragging the corner.
    ---@type NK_Window_Flags
    scalable = 'scalable',
    ---The window can be closed by clicking the close button.
    ---@type NK_Window_Flags
    closable = 'closable',
    ---The window can be collapsed by clicking the minimize button.
    ---@type NK_Window_Flags
    minimizable = 'minimizable',
    ---Include a scrollbar for the window.
    ---@type NK_Window_Flags
    scrollbar = 'scrollbar',
    ---Display the window title on the header.
    ---@type NK_Window_Flags
    title = 'title',
    ---Automatically hide the scrollbar after a period of inactivity.
    ---@type NK_Window_Flags
    scrollAutoHide = 'scroll auto hide',
    ---Keep the window behind all other windows.
    ---@type NK_Window_Flags
    background = 'background',
}


---@class NK_Layout_Mode_Static :NK_Layout_Mode
--

---@class NK_Layout_Mode_Dynamic :NK_Layout_Mode
--

---@class NK_Layout_Mode
NK_Layout_Mode = {
    ---@type NK_Layout_Mode_Dynamic
    dynamic = 'dynamic',
    ---@type NK_Layout_Mode_Static
    static = 'static',
}

---@class NK_Tree_Type
NK_Tree_Type = {
    ---@type NK_Tree_Type
    node = 'node',
    ---@type NK_Tree_Type
    tab = 'tab',
}

---@class NK_Collapsed_Type
NK_Collapsed_Type = {
    ---@type NK_Collapsed_Type
    collapsed = 'collapsed',
    ---@type NK_Collapsed_Type
    expanded = 'expanded',
}

---Various widgets accept `symbol` type strings as parameters. Here is a complete list of symbol types:
---@class NK_Symbols
NK_Symbols = {
    ---@type NK_Symbols
    none = 'none',
    ---@type NK_Symbols
    x = 'x',
    ---@type NK_Symbols
    underscore = 'underscore',
    ---@type NK_Symbols
    circleSolid = 'circle solid',
    ---@type NK_Symbols
    circleOutline = 'circle outline',
    ---@type NK_Symbols
    rectSolid = 'rect solid',
    ---@type NK_Symbols
    rectOutline = 'rect outline',
    ---@type NK_Symbols
    triangleUp = 'triangle up',
    ---@type NK_Symbols
    triangleDown = 'triangle down',
    ---@type NK_Symbols
    triangleLeft = 'triangle left',
    ---@type NK_Symbols
    triangleRight = 'triangle right',
    ---@type NK_Symbols
    plus = 'plus',
    ---@type NK_Symbols
    minus = 'minus',
}
---Some widgets accept alignment arguments for text, symbols, and/or images. Here is a complete list of alignment types:
---@class NK_Alignment

---Some widgets accept alignment arguments for text, symbols, and/or images. Here is a complete list of alignment types:
---@type NK_Alignment
NK_Alignment = {
    ---@type NK_Alignment
    left = 'left',
    ---@type NK_Alignment
    centered = 'centered',
    ---@type NK_Alignment
    right = 'right',
    ---@type NK_Alignment
    topLeft = 'top left',
    ---@type NK_Alignment
    topCentered = 'top centered',
    ---@type NK_Alignment
    topRight = 'top right',
    ---@type NK_Alignment
    bottomLeft = 'bottom left',
    ---@type NK_Alignment
    bottomCentered = 'bottom centered',
    ---@type NK_Alignment
    bottomRight = 'bottom right',
}

---@class NK_Alignment_Wrap

---@type NK_Alignment_Wrap
NK_Alignment_Wrap = 'wrap'

---@class NK_ButtonBehavior

---@type NK_ButtonBehavior
NK_ButtonBehavior_Default = 'default'
---@type NK_ButtonBehavior
NK_ButtonBehavior_Repeater = 'repeater'

---@class NK_ColorMode

---@type NK_ColorMode
NK_ColorMode_RGB = 'RGB'
---@type NK_ColorMode
NK_ColorMode_RGBA = 'RGBA'

---@class NK_EditType

NK_EditType = {
    ---@type NK_EditType
    simple = 'simple',
    ---@type NK_EditType
    field = 'field',
    ---@type NK_EditType
    box = 'box',
}

---@class NK_MouseButtonType
NK_MouseButtonType = {
    ---@type NK_MouseButtonType
    left = 'left',
    ---@type NK_MouseButtonType
    right = 'right',
    ---@type NK_MouseButtonType
    middle = 'middle',
}

local defaultColors = {
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

---@class NK_ColorTable
---@field public text string
---@field public window string
---@field public header string
---@field public border string
---@field public button string
---@field public buttonHover string
---@field public buttonActive string
---@field public toggle string
---@field public toggleHover string
---@field public toggleCursor string
---@field public select string
---@field public selectActive string
---@field public slider string
---@field public sliderCursor string
---@field public sliderCursorHover string
---@field public sliderCursorActive string
---@field public property string
---@field public edit string
---@field public editCursor string
---@field public combo string
---@field public chart string
---@field public chartColor string
---@field public chartColorHighlight string
---@field public scrollbar string
---@field public scrollbarCursor string
---@field public scrollbarCursorHover string
---@field public scrollbarCursorActive string
---@field public tabHeader string

---@return NK_ColorTable
---@param tb NK_ColorTable
function NK_ColorTable(tb)
    tb = tb or {}
    for i, v in pairs(defaultColors) do
        if not tb[i] then
            tb[i] = defaultColors[i]
        end
    end
    return tb
end

NK_ColorTableFields = {
    text = "text",
    window = "window",
    header = "header",
    border = "border",
    button = "button",
    buttonHover = "button hover",
    buttonActive = "button active",
    toggle = "toggle",
    toggleHover = "toggle hover",
    toggleCursor = "toggle cursor",
    select = "select",
    selectActive = "select active",
    slider = "slider",
    sliderCursor = "slider cursor",
    sliderCursorHover = "slider cursor hover",
    sliderCursorActive = "slider cursor active",
    property = "property",
    edit = "edit",
    editCursor = "edit cursor",
    combo = "combo",
    chart = "chart",
    chartColor = "chart color",
    chartColorHighlight = "chart color highlight",
    scrollbar = "scrollbar",
    scrollbarCursor = "scrollbar cursor",
    scrollbarCursorHover = "scrollbar cursor hover",
    scrollbarCursorActive = "scrollbar cursor active",
    tabHeader = "tab header",
}
