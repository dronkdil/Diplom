'use client'
import { AccentButton, DefaultButton, GhostButton, IconButton } from "@/components/buttons"
import { SwitchCheckbox } from "@/components/form"
import { DefaultInput } from "@/components/form/input"
import Searchbar from "@/components/form/searchbar/Searchbar"
import Logo from "@/components/logo/Logo"
import { SearchIcon, User2Icon } from "lucide-react"

const page = () => {
  return (
    <div className="grid gap-2 p-10">
      <div className="flex gap-2">
        <DefaultButton>Далі</DefaultButton>
        <AccentButton>Далі</AccentButton>
        <GhostButton>Далі</GhostButton>
        <IconButton><SearchIcon /></IconButton>
      </div>
      <div className="flex gap-2">
        <DefaultInput icon={<User2Icon />} placeholder="text" />
        <Searchbar onClick={(value) => console.log(value)} />
      </div>
      <div className="flex gap-2">
        <SwitchCheckbox />
      </div>
      <div className="flex gap-2">
        <Logo />
      </div>
    </div>
  )
}

export default page
