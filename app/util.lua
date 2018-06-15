function rgba(hex)
    hex = hex:gsub("#", "")
    color = { tonumber("0x" .. hex:sub(1, 2)) / 255,
              tonumber("0x" .. hex:sub(3, 4)) / 255,
              tonumber("0x" .. hex:sub(5, 6)) / 255 }
    if string.len(hex) >= 8 then
        table.insert(color, tonumber("0x" .. hex:sub(7, 8)) / 255)
    end
    return color
end