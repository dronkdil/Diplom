'use client'
import { cn } from "@/lib/utils"
import { SearchIcon } from "lucide-react"
import { useState } from "react"
import { IconButton } from "../../buttons"
import { DefaultInput } from "../input"
import styles from './Searchbar.module.scss'

interface SearchbarProps {
  onClick?(value: string): void
}

const Searchbar = ({onClick}: SearchbarProps) => {
  const [value, setValue] = useState("")

  return (
    <DefaultInput
        icon={<IconButton onClick={() => onClick && onClick(value)}>
          <SearchIcon />
        </IconButton>} 
        placeholder="Пошук" 
        wrapperClassName={cn(styles.searchbar)}
        value={value}
        onChange={(e) => setValue(e.target.value)}
        onKeyDown={(e) => {
          if (e.key === "Enter") {
            e.preventDefault()
            onClick && onClick(value)
          }
        }}
    />
  )
}

export default Searchbar
