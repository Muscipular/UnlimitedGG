local FadeSystem = tiny.processingSystem(Base:extend())
FadeSystem.filter = tiny.requireAll("fadeTime", "alpha")

function FadeSystem:process(e, dt)
	e.alpha = math.min(1, math.max(0, e.alpha - dt / e.fadeTime))
end

return FadeSystem
