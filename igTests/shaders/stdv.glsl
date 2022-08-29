#version 440 core

layout(location = 0) in vec4 aPosition;
layout(location = 1) in vec4 aTexCoord;
layout(location = 4) in mat4 aModel;

out vec4 UVs;
out uint iID;

uniform mat4 worldToClip;

void main()
{
	UVs = aTexCoord;
	iID = gl_InstanceID;
	gl_Position = aPosition * aModel * worldToClip;
}