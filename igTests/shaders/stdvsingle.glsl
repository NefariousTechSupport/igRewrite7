#version 440 core

layout(location = 0) in vec4 aPosition;
layout(location = 1) in vec4 aTexCoord;
layout(location = 2) in vec4 aColour;

out vec4 UVs;
out vec4 vColour;

uniform mat4 world;

void main()
{
	UVs = aTexCoord;
	vColour = aColour;
	gl_Position = aPosition * world;
}