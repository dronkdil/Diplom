import { cn } from "@/lib/utils"
import styles from "./Skeleton.module.scss"

type SkeletonProps = {
    className: string
}

const Skeleton = ({className}: SkeletonProps) => {
  return (
    <div className={cn(styles.skeleton, className)}></div>
  )
}

export default Skeleton
