import { Comment } from "./comment";

export interface Profile {
    username: string;
    picturePath: string;
    firstName: string;
    lastName: string;
    birthday: Date;
    description: string;
    comments: Comment[];
}
