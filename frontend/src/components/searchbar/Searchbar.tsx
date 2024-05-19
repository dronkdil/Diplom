'use client'
import { SearchIcon } from "lucide-react"
import { useState } from "react"
import { IconButton } from "../buttons"
import { DefaultInput } from "../form/input"
import styles from './Searchbar.module.scss'

interface SearchbarProps {
  onClick?(value: string): void
}

const Searchbar = ({onClick}: SearchbarProps) => {
  const [value, setValue] = useState("")

  return (
    <DefaultInput
        icon={<IconButton onClick={() => onClick && onClick(value)}>
          <SearchIcon className="stroke-black" />
        </IconButton>} 
        placeholder="Пошук" 
        wrapperClassName={styles.searchbar}
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
