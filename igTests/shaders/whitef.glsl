#version 440 core

out vec4 color;

in vec4 UVs;

uniform sampler2D albedo;
uniform bool useTexture;

void main()
{
	color = vec4(1.0);
}