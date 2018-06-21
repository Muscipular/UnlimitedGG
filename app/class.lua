--
-- classic
--
-- Copyright (c) 2014, rxi
--
-- This module is free software; you can redistribute it and/or modify it under
-- the terms of the MIT license. See LICENSE for details.
--
---@class Base
---@field protected super
local Base = {}
Base.__index = Base

function Base:new()
end

function Base:extend(name)
    local cls = {}
    for k, v in pairs(self) do
        if k:find("__") == 1 then
            cls[k] = v
        end
    end
    cls.__index = cls
    cls._name = name
    cls.super = self
    setmetatable(cls, self)
    return cls
end

function Base:implement(...)
    for _, cls in pairs({ ... }) do
        for k, v in pairs(cls) do
            if self[k] == nil and type(v) == "function" then
                self[k] = v
            end
        end
    end
end

function Base:is(T)
    local mt = getmetatable(self)
    while mt do
        if mt == T then
            return true
        end
        mt = getmetatable(mt)
    end
    return false
end

function Base:__tostring()
    return self._name or "Object"
end

local id = 1
function Base:__call(...)
    id = id + 1
    local obj = setmetatable({
        _id = id
    }, self)
    obj:new(...)
    return obj
end

_G.Base = Base;
return Base
