#version 440 core

layout(location = 0) in vec4 aPosition;
layout(location = 1) in vec4 aTexCoord;
layout(location = 2) in vec4 aColour;
layout(location = 4) in mat4 aModel;

out vec4 UVs;
out uint iID;
out vec4 vColour;

uniform mat4 worldToClip;

void main()
{
	UVs = aTexCoord;
	vColour = aColour;
	iID = gl_InstanceID;
	gl_Position = aPosition * aModel * worldToClip;
}