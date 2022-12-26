import { ProjectState } from "./project-state";

export class Project {
    private id: number;
    private name: { [key: string]: string };
    private description: { [key: string]: string };
    private imageUrl: string;
    private state: ProjectState;

    constructor(id: number, name: { [key: string]: string }, description: { [key: string]: string }, imageUrl: string, state: ProjectState = ProjectState.draft) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.imageUrl = imageUrl;
        this.state = state;
    }

    getName(locale: string) : string {
        return this.name[locale];
    }

    getDescription(locale: string) : string {
        return this.description[locale];
    }

    getImageUrl() : string {
        return this.imageUrl;
    }

    getState() : ProjectState {
        return this.state;
    }

    isDraft() : boolean {
        if (this.state == ProjectState.draft) {
            return true;
        }
        else {
            return false;
        }
    }
}