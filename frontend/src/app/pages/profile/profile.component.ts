import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Profile } from 'src/app/interfaces/profile';
import { PublicService } from 'src/app/services/public.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public profile: Profile = {
    username: '',
    picturePath: '',
    firstName: '',
    lastName: '',
    birthday: new Date(),
    description: '',
    comments: []
  };

  constructor(private publicService: PublicService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params: any) => {
      if (params && params.username) {
        this.getProfile(params.username);
      }
    });
  }

  getProfile(username: string) {
    this.publicService.getProfile(username).subscribe((response: any) => {
      this.profile = response;
    });
  }
}
