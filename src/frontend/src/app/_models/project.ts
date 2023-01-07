import { ProjectState } from "./project-state";

export class Project {
    id: number;
    name: { [key: string]: string };
    description: { [key: string]: string };
    imageUrl: string;
    projectUrl: string;
    state: ProjectState;

    constructor(id: number, name: { [key: string]: string }, description: { [key: string]: string }, imageUrl: string, projectUrl: string, state: ProjectState = ProjectState.draft) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.imageUrl = imageUrl;
        this.projectUrl = projectUrl;
        this.state = state;
    }
}