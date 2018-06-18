local SpriteSystem = tiny.processingSystem(Base:extend())
SpriteSystem.isDrawSystem = true

function SpriteSystem:new(layerFlag)
    self.filter = tiny.requireAll("sprite", "pos", function(s, e)
        return e.zIndex == layerFlag
    end)
end

--function SpriteSystem:preProcess(dt)
--end
--
--function SpriteSystem:postProcess(dt)
--    --love.graphics.setColor(1, 1, 1, 1)
--end

function SpriteSystem:process(e, dt)
    local alpha = e.alpha or 1
    if alpha <= 0 then
        return
    end
    local an = e.animation
    local pos, sprite, scale, rot, offset = e.pos, e.sprite, e.scale, e.rot, e.offset
    local sx, sy, r, ox, oy = scale and scale.x or 1, scale and scale.y or 1, rot or 0, offset and offset.x or 0, offset and offset.y or 0

    local co = { love.graphics.getColor() }
    love.graphics.setColor(1, 1, 1, math.max(0, math.min(1, alpha)))
    if an then
        an.flippedH = e.flippedH or false
        an.flippedV = e.flippedV or false
        an:update(dt)
        an:draw(sprite, pos.x, pos.y, r, sx, sy, ox, oy)
    else
        love.graphics.draw(sprite, pos.x, pos.y, r, sx, sy, ox, oy)
    end
    if e.draw then
        e:draw(dt)
    end
    love.graphics.setColor(unpack(co))
end

return SpriteSystem
