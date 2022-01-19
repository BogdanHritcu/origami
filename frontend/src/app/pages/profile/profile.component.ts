import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Comment } from 'src/app/interfaces/comment';
import { Profile } from 'src/app/interfaces/profile';
import { PublicService } from 'src/app/services/public.service';
import { PrivateService } from 'src/app/services/private.service';
import { FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  private myUsername: string = ''+localStorage.getItem('username');
  private profileUsername: string = '';

  public profile: Profile = {
    username: '',
    picturePath: '',
    firstName: '',
    lastName: '',
    birthday: new Date(),
    description: '',
    comments: []
  };

  public commentForm!: FormGroup;

  constructor(private publicService: PublicService,
    private privateService: PrivateService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params: any) => {
      if (params && params.username) {
        this.profileUsername = params.username;
        this.getProfile(this.profileUsername);
      }
    });

    this.commentForm = this.formBuilder.group({
      text: ['', [Validators.required]]
    });
  }

  getProfile(username: string) {
    this.publicService.getProfile(username).subscribe((response: any) => {
      this.profile = response;
    });
  }

  postComment() {
    if (this.commentForm.valid) {
      var comment: Comment = {
        username: '' + this.myUsername,
        picturePath: '',
        body: '' + this.commentForm.get('text')?.value
      };
      this.privateService.postComment(comment, this.profileUsername).subscribe((response: any) => {
        if (response && response.username === this.myUsername) {
          console.log("Comment posted.")
          this.ngOnInit();
        } else {
          console.log("Comment not posted.")
        }
      });
    }
  }

  deleteComment(comment: Comment) {
    this.privateService.deleteComment(comment).subscribe((response: any) => {
      if (response && response.username === this.myUsername) {
        console.log("Comment deleted.")
        this.ngOnInit();
      } else {
        console.log("Comment not deleted.")
      }
    });
  }
}
