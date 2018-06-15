---@class Application: Component
---@protected _ctx
---@protected imgDir string
---@protected fontDir string
---@protected fontDefault string
Application = {}

function Application:New()
    newInstance = new(self, Component)
    local graphics = love.graphics
    self._ctx = {}
    self.imgDir = "/image/"
    self.fontDir = "/font/"
    self.fontDefault = graphics.newFont(self.fontDir .. "sh.otf", 13)
    self.t = 0
    local style = {
        font = self.fontDefault,
        showBorder = true,
        fgColor = rgba('#000000'),
        bgColor = rgba('#FFFFFF'),
    }
    graphics.setFont(self.fontDefault)
    graphics.setColor({ 0, 0, 0 })
    graphics.setBackgroundColor(rgba("#FFFFFF"))
    graphics.setDefaultFilter("nearest", "nearest")

    gooi.setStyle(style)
    gooi.desktopMode()
    self.label = gooi:newLabel({ text = "AAAA" }):fg("#000000");
    self:addChild(self.label)
    return newInstance;
end

function Application:update(dt)
    gooi.update(dt)
    self.t = self.t + dt;
    if self.t > 10 then
        gooi.removeComponent(self.label)
        self.label = nil
    end
end

function Application:draw()
    gooi.draw()
    love.graphics.print("FPS: " .. love.timer.getFPS())
end

function Application:pressed(x, y, button)
    gooi.pressed()
end

function Application:mousePressed(x, y, button)
end

function Application:mouseReleased(x, y, button)
    gooi.released()
end

function Application:textInput(text)
    gooi.textinput(text)
end

function Application:keyPressed(k, code, isrepeat)
    gooi.keypressed(k, code, isrepeat)
end

function Application:keyReleased(k, code, isrepeat)
    gooi.keyreleased(k, code, isrepeat)
end

return Application