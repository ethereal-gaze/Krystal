#version 460 core

layout (location = 0) in vec3 vertex_position;
layout (location = 1) in vec2 texture_coordinates;

uniform mat4 glModel;
uniform mat4 glView;
uniform mat4 glProjection;
uniform float deltaTime;

out vec2 texUVs;

void main()
{
    gl_Position = glProjection * glView * glModel * vec4(vertex_position, 1.0f);
    texUVs = texture_coordinates;
}