import { ProjectState } from "../enums/project-state";

export class Project {
  private id: number;
  private name: Map<string, string>;
  private description: Map<string, string>;
  private state: ProjectState;
  private imageUrl: string;

  constructor(id: number, name: Map<string, string>, description: Map<string, string>, state: ProjectState, imageUrl: string) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.state = state;
    this.imageUrl = imageUrl;
  }

  getName(locale: string) : string | undefined {
    return this.name.get(locale);
  }

  getDescription(locale: string) : string | undefined {
    return this.description.get(locale);
  }

  getState(): ProjectState {
    return this.state;
  }

  getImageUrl(): string {
    return this.imageUrl;
  }
}
