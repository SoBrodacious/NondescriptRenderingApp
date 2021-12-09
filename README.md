# Nondescript Rendering App
A simple WPF App that can draw shapes to a canvas

## Contents
1. [Goal](#goal)
2. [Accomplished](#accomplished)
3. [Additional Niceness (Accidental Learnings)](#additional-niceness-(accidental-learnings))
4. [Known Issues / Future Expansions](#known-issues-/-future-expansions)
5. [Closing Thoughts](#closing-thoughts)

### Goal
With this project, I wanted to look into Windows Presentation Foundation (WPF) applications through the construction of a simple rendering application within the timespan of about a week. It is also a chance to refresh myself on C#, software design patterns, and other general good software engineering practice.

### Accomplished
By the end of this project, I have been able to create a small application that has a control panel and a graphics panel, can draw assorted shapes which derive from either a typical polygon, or an ellipse. These shapes can be subjected to different animations, provided those animations are in the from of point to point, or a series of point to point animations.

### Additional Niceness (Accidental Learnings)
In addition to what I set out to achieve, this project has given me a chance to get hands on with a whole slew of additional technologies and concepts that I had no idea about while heading into it. 

#### WPF
While I had a vague idea of what WPF was, I had never looked into it other than a cursory glance at UI and code-behind. Working on this project, I have found it incredibly interesting to look deeper into WPF, and concepts like data binding, and how they can blend design and development into a single, neat, and powerful package. Add an MVVM framework on top and you can write some pretty amazing implicit code.

#### MVVM
WPF applications /can/ be made with a MVC mindset, however when looking around online, I saw that another common design pattern used for WPF is that of MVVM, which I had not encountered until starting this project. MVVM is great, but what is even better is the many frameworks people have produced to help developers implement this pattern faster, and stick to it. I explored Caliburn, ReactiveUI, and Prism, and ended up sticking with Prism, as the documentation was a bit more palatable for someone like me who was new to both WPF and MVVM as a whole.

#### XML
I haven't had great opportunity to use it in a custom format sense, but after this project, I am greatly appreciative of the power of XML for defining custom data types, and the ease of reading them into a program.

### Known Issues / Future Expansions
As this was a time limited project, there are some issues, and I did not manage to implement all the functionality I would have liked to. That said, I am pretty pleased with the feature coverage I managed to get, given that many of these technologies I had limited exposure to before the start of the week.

#### Addition: Color picker
It would be quite nice to either implement or find a widget for a simple color picker, and use that value as the generative value for creating a polygon. Currently the polygon colors are defined in their XML definition, and cannot be changed at runtime.

#### Experiment: Animation
The animation system is set up in a way that it should be easy enough to expand upon, however it does leverage off of the WPF library implementations of animations, and while these are very good, they are quite obtuse, and very feature dense. If I had a lot more time, I might look into a way to animate these values myself, to strip away some of the complexities associated with trying to animate in an environment where almost everything is animatable.

#### Rebuild: Canvas
The canvas system that is in the application is a bit scuffed, as to get shape generation to work programmatically in an MVVM sense, I have had to add a layer of obfuscation between the canvas, and the shape that is being drawn on it. This makes it a little harder to take into account things like shapes clipping off the edge of the canvas when moved about

### Closing Thoughts
This was a fun project, and I am feeling a lot more confident about working with WPF. I will be using it to write more applications in future


