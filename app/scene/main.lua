---@type nuklear
local nk = require 'nuklear'
local Component = require('app.component.base')
local helper = require('app.scene.helper')
local deep = require('lib.deep')

---@class MainScene : Component
local MainScene = Component:extend()
---@type love_graphics
local g;

function MainScene:new()
    self.super.new(self)
end

function MainScene:enter()
    g = love.graphics
    love.mouse.setCursor(love.mouse.getSystemCursor(CursorType.arrow))
end

function MainScene:resume()

end

function MainScene:leave()

end

local layers = {
    bg = 0,
    panel = 10,
    control = 20,
    text = 30,
    pop = 40,
}

function MainScene:draw()
    g.clear(rgba('#ccc'))
    self:drawInfo();
    deep.queue(layers.panel, function()
        g.push(StackType.all)
        g.setColor(rgba('#eeeeee'))
        g.rectangle(DrawMode.fill, 5, 160, 450, g.getHeight() - 160 - 5);
        g.pop();
    end);

    deep.queue(layers.text, function()
        g.push(StackType.all)
        g.setColor(rgba('#000'))
        g.printf("SSS", 10, 160 + 10, 50, AlignMode.left)
        g.pop();
    end);
end

function MainScene:drawInfo()
    local maxWidth = 450;
    local maxHeight = 150;
    local cols = { 0, 45, 160, 200, 250, 290, 350, 390 }
    local function ox(x) return x + 5 end
    local function oxc(n) return ox(cols[n + 1] + 5) end
    local function oy(y) return y + 5 end
    local function oyc(n) return oy(n * 20 + 5) end
    deep.queue(layers.panel, function()
        g.push(StackType.all)
        g.setColor(rgba('#eeeeee'))
        g.rectangle(DrawMode.fill, ox(0), oy(0), maxWidth, maxHeight);
        g.pop();
    end);

    function drawBar(x, y, w, h, p, c1, c2, tips)
        c1 = rgba(c1 or '#3e1')
        c2 = rgba(c2 or '#999')
        g.push(StackType.all)
        g.setColor(c2)
        local x2, y2 = ox(x), oy(y)
        g.rectangle(DrawMode.fill, x2, y2, w, h, 1, 1);
        g.setColor(c1)
        g.rectangle(DrawMode.fill, ox(x), oy(y), w * math.min(p, 1), h, 1, 1);
        local x1 = love.mouse.getX();
        local y1 = love.mouse.getY();
        if tips and (x1 >= x2 and x1 <= x2 + w and y1 >= y2 and y1 <= y2 + h) then
            deep.queue(layers.pop, function()
                local txt = g.newText(application.fontDefault, "");
                txt:setf(tips, 100, AlignMode.left);
                g.setColor(rgba('#ccc'))
                g.rectangle(DrawMode.fill, x1 + 8, y1 + 8, 110, txt:getHeight() + 10, 2, 2);
                g.setColor(0, 0, 0, 1)
                g.draw(txt, x1 + 8 + 5 + (100 - txt:getWidth()) / 2, y1 + 8 + 5);
            end)
        end
        g.pop();
    end

    deep.queue(layers.control, function()
        local y = math.floor(love.timer.getTime() * 10) % 100;
        drawBar(ox(45), oy(11 + 60), 100, 3, y / 100, y < 20 and '#e33' or y < 50 and '#ee3' or nil, nil, fmt('%s / %s', y, 100))
        drawBar(ox(45), oy(11 + 80), 100, 3, 20.0 / 100, '#e33', nil, fmt('%s / %s', 20, 100))
        drawBar(ox(45), oy(11 + 100), 100, 3, 99.5 / 100, nil, nil, fmt('%s / %s', 99.5, 100))
    end)

    deep.queue(layers.text, function()
        g.push(StackType.all)
        g.setColor(rgba('#333'))
        g.printf("名字:", oxc(0), oyc(0), 40, AlignMode.left)
        g.printf("SSS", oxc(1), oyc(0), 110, AlignMode.left)
        g.printf("等级:", oxc(0), oyc(1), 40, AlignMode.left)
        g.printf("1", oxc(1), oyc(1), 110, AlignMode.left)
        g.printf("种族:", oxc(0), oyc(2), 40, AlignMode.left)
        g.printf("Human", oxc(1), oyc(2), 110, AlignMode.left)
        g.printf("HP:", oxc(0), oyc(3), 40, AlignMode.left)
        --g.printf("80", ox(50), oy(5 + 60), 160, AlignMode.left)
        g.printf("MP:", oxc(0), oyc(4), 40, AlignMode.left)
        --g.printf("80", ox(50), oy(5 + 80), 160, AlignMode.left)
        g.printf("EXP:", oxc(0), oyc(5), 40, AlignMode.left)
        --g.printf("80", ox(50), oy(5 + 100), 160, AlignMode.left)
        g.printf("Gold:", oxc(0), oyc(6), 40, AlignMode.left)
        g.printf("1234567890123", oxc(1), oyc(6), 110, AlignMode.left)
        g.printf("Str:", oxc(2), oyc(1), 40, AlignMode.left)
        g.printf("9999", oxc(3), oyc(1), 110, AlignMode.left)
        g.printf("Dex:", oxc(2), oyc(2), 40, AlignMode.left)
        g.printf("10", oxc(3), oyc(2), 110, AlignMode.left)
        g.printf("Vit:", oxc(2), oyc(3), 40, AlignMode.left)
        g.printf("10", oxc(3), oyc(3), 110, AlignMode.left)
        g.printf("Agi:", oxc(2), oyc(4), 40, AlignMode.left)
        g.printf("10", oxc(3), oyc(4), 110, AlignMode.left)
        g.printf("Int:", oxc(2), oyc(5), 40, AlignMode.left)
        g.printf("10", oxc(3), oyc(5), 110, AlignMode.left)
        g.printf("Luk:", oxc(2), oyc(6), 40, AlignMode.left)
        g.printf("10", oxc(3), oyc(6), 110, AlignMode.left)
        g.printf("攻击:", oxc(4), oyc(1), 40, AlignMode.left)
        g.printf("10 ~ 99", oxc(5), oyc(1), 180, AlignMode.left)
        g.printf("魔功:", oxc(4), oyc(2), 40, AlignMode.left)
        g.printf("1 ~ 1", oxc(5), oyc(2), 180, AlignMode.left)
        g.printf("暴击:", oxc(4), oyc(3), 40, AlignMode.left)
        g.printf("10", oxc(5), oyc(3), 110, AlignMode.left)
        g.printf("防御:", oxc(4), oyc(4), 40, AlignMode.left)
        g.printf("10", oxc(5), oyc(4), 110, AlignMode.left)
        g.printf("魔防:", oxc(4), oyc(5), 40, AlignMode.left)
        g.printf("10", oxc(5), oyc(5), 110, AlignMode.left)
        g.printf("MF:", oxc(4), oyc(6), 40, AlignMode.left)
        g.printf("100%", oxc(5), oyc(6), 110, AlignMode.left)
        --g.printf("攻击:", oxc(6), oyc(1), 40, AlignMode.left)
        --g.printf("10", oxc(7), oyc(1), 110, AlignMode.left)
        --g.printf("魔功:", oxc(6), oyc(2), 40, AlignMode.left)
        --g.printf("10", oxc(7), oyc(2), 110, AlignMode.left)
        g.printf("爆伤:", oxc(6), oyc(3), 40, AlignMode.left)
        g.printf("1000%", oxc(7), oyc(3), 110, AlignMode.left)
        g.printf("护甲:", oxc(6), oyc(4), 40, AlignMode.left)
        g.printf("1000", oxc(7), oyc(4), 110, AlignMode.left)
        g.printf("魔抗:", oxc(6), oyc(5), 40, AlignMode.left)
        g.printf("1000", oxc(7), oyc(5), 110, AlignMode.left)
        g.printf("GF:", oxc(6), oyc(6), 40, AlignMode.left)
        g.printf("1000%", oxc(7), oyc(6), 110, AlignMode.left)
        g.pop();
    end);
end

function MainScene:update(dt)

end

return MainScene