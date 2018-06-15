require("lib.gooi")
require("imgui")
require("lib.app")
rgba = gooi.toRGBA

---@type Application
application = nil

function love.load()
    --application = class.instance()
end

function love.mousepressed(x, y, button)
    --Application:mousePressed(x, y, button)
end

function love.mousereleased(x, y, button)
    --Application:mouseReleased(x, y, button)
end

function love.textinput(text)
    --Application:textInput(text)
end

function love.keypressed(k, code, isrepeat)
    --Application:keyPressed(k, code, isrepeat)
end

function love.keyreleased(k, code, isrepeat)
    --Application:keyReleased(k, code, isrepeat)
end

function love.update(dt)
    imgui.NewFrame("")
    --application:update(dt)
end

function love.draw()
    imgui.Text("Hello, world!");
    imgui.Render()
    --application:draw()
end