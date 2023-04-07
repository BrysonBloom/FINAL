import { Account } from "./Account";

export class Keep {
    constructor(data) {
        this.id = data.id;
        this.creatorId = data.creatorId;
        this.name = data.name;
        this.description = data.description;
        this.img = data.img;
        this.views = data.views;
        this.kept = data.kept;
        this.vaultKeepId = data.vaultKeepId;
        this.creator = new Account(data.creator);
    }
}