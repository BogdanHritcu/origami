import { Step } from "./step";
import { Comment } from "./comment";

export interface Origami {
    username: string;
    id: string;
    name: string;
    pricturePath: string;
    description: string;
    videoPath: string;
    difficulty: number;
    estimatedTime: number;
    steps: Step[];
    comments: Comment[];
}
