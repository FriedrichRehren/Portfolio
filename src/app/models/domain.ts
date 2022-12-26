export class Domain {
    private id: number;
    private name: string;
    private description: { [key: string]: string };

    constructor(id: number, name: string, description: { [key: string]: string }) {
        this.id = id;
        this.name = name;
        this.description = description;
    }

    getName() : string {
        return this.name;
    }

    getDescription(locale: string) : string {
        return this.description[locale];
    }
}
