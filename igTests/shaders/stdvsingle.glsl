#version 440 core

layout(location = 0) in vec4 aPosition;
layout(location = 1) in vec4 aTexCoord;

out vec4 UVs;

uniform mat4 world;

void main()
{
	UVs = aTexCoord;
	gl_Position = aPosition * world;
}