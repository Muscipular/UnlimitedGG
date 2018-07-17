function rgba(hex)
    if type(hex) == "table" then
        return hex
    end
    hex = hex:gsub("#", "")
    local l = string.len(hex)
    if l == 3 then
        return {
            tonumber("0x" .. hex:sub(1, 1) .. hex:sub(1, 1)) / 255,
            tonumber("0x" .. hex:sub(2, 2) .. hex:sub(2, 2)) / 255,
            tonumber("0x" .. hex:sub(3, 3) .. hex:sub(3, 3)) / 255,
            1
        }
    end
    if l == 4 then
        return {
            tonumber("0x" .. hex:sub(1, 1) .. hex:sub(1, 1)) / 255,
            tonumber("0x" .. hex:sub(2, 2) .. hex:sub(2, 2)) / 255,
            tonumber("0x" .. hex:sub(3, 3) .. hex:sub(3, 3)) / 255,
            tonumber("0x" .. hex:sub(4, 4) .. hex:sub(4, 4)) / 255,
        }
    end
    color = {
        tonumber("0x" .. hex:sub(1, 2)) / 255,
        tonumber("0x" .. hex:sub(3, 4)) / 255,
        tonumber("0x" .. hex:sub(5, 6)) / 255,
        1
    }
    if l >= 8 then
        color[4] = tonumber("0x" .. hex:sub(7, 8)) / 255
    end
    return color
end

function fmt(s, ...)
    return string.format(s, ...)
end

function printf(s, ...)
    print(fmt(s, ...))
end

function printAsJson(e)
    print(JSON:encode(e))
end

function keys(t)
    local r = {}
    for i, v in pairs(t) do
        table.insert(r, i)
    end
    return r
end

sort = table.sort;

function revert(t)
    local k, l = 0, #t
    for i = 1, math.floor(l / 2) do
        k = t[l + 1 - i]
        t[l + 1 - i] = t[i]
        t[i] = k
    end
end

function toDictionary(t, fn)
    local r = {}
    for i, v in pairs(t) do
        local k, val = fn(v, i)
        r[k] = val
    end
    return r
end

function take(t, n, skip)
    local r = {}
    if not skip then
        skip = 0
    end
    for i = 1 + skip, math.min(#t, n) do
        r[i] = t[i]
    end
    return r;
end

----@return {key,value}[]
function dicToArray(t)
    local r = {}
    for i, v in pairs(t) do
        table.insert(r, { key = i, value = v })
    end
    return r
end

function map(t, fn)
    local r = {}
    for i, v in ipairs(t) do
        table.insert(r, fn(v, i))
    end
    return r
end

function filter(t, fn)
    local r = {}
    for i, v in ipairs(t) do
        if fn(v, i) then
            table.insert(r, v)
        end
    end
    return r
end

function any(t, fn)
    for i, v in ipairs(t) do
        if fn(v, i) then
            return true
        end
    end
    return false
end
function all(t, fn)
    for i, v in ipairs(t) do
        if not fn(v, i) then
            return false
        end
    end
    return true
end

function contains(t, v)
    for i, v in pairs(t) do
        if v == t then
            return true;
        end
    end
end
