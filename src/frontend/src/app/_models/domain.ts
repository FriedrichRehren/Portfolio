export class Domain {
    id: number;
    name: string;
    description: { [key: string]: string };

    constructor(id: number, name: string, description: { [key: string]: string }) {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}
