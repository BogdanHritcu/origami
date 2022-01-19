import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Comment } from 'src/app/interfaces/comment';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {
  public myUsername: string = '';

  @Input() comment: Comment = {
    id: '',
    username: '',
    picturePath: '',
    body: ''
  };

  @Output() onDeleteComment: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
    this.myUsername = '' + localStorage.getItem('username');
  }

  deleteComment(comment: Comment) {
    this.onDeleteComment.emit(comment);
  }
}
