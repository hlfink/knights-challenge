import { attribute } from "src/app/attribute"
import { weapon } from "src/app/weapon"

export interface knightRequest{
birthday: Date
attributes: attribute<number>
keyAttribute : string
name : string,
nickName : string,
weapons : weapon[]
}