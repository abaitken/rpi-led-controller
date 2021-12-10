# Raspberry Pi Addressable LED Controller

Various animations, patterns and timings for addressable LED lights.

## Concepts

### Pattern

The colours which are applied across the LED strip.

A pattern may not change the state of the lighting strip.

A pattern may change from step to step, a scene should ensure it called the ```NextState```.

### Animation

An animation is the way in which the pattern is applied to the LED strip.

An animation may ignore the pattern for the purposes of filling colour and may also ignore the exact indexes the pattern provides as part of its animation (e.g. sliding animation).

The animation is responsible for calling ```Update``` on the lighting controller, as many times as required.

### Timing

The delay in between each step of the animation.

The scene should invoke the ```Delay``` method after calling the animation ```Step```.

### Scene

A combination of a single animation, pattern and timing.

### Demo

A combination of multiple scenes.

## TODO

- Implement animations:
    - Combination animations
        - One followed by another
    - Nightrider
		- Combo sections slide left + slide irght
    - Section Loop around
		- Combo sections slide left/right multiple times
    - Twinkling
- Implement timings
    - Repeating set of values (e.g. 25ms then 10ms then 50ms, repeat)
    - Add microphone and support bpm?
- Implement patterns
    - Colour stops with various different calculations for inbetween colours
    - Colour sections
	- Store random colour values to support consistent colours when shifting
    - Pallettes of colour
- Define sequences via parsing a special string
	- e.g. 'A=FR;P=R;T=C,25;A=FL' (Animation fill right, Palette is random, Timing is constant 25ms, then animate Fill left, then repeat)
	- Subsequent palettes/timings just change the current settings until overridden
	- Provide brightness override
- Complete executable/main library with LED WS2812/ILightingController implementation
- Implement LAN communication
	- Implement a technique to send instructions
		- Post a string to a simple web server with various patterns/palettes etc?
		- Create RPI app to provide controls for sending string
- Add circuit diagram

## Bugs

- Sometimes there is a long pause on a single pattern (FIXED? Needs Testing)
- Sometimes there an odd color left over on the first/last LED (FIXED? Needs Testing)

